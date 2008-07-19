/*
GPG Desktop is a graphical frontend for GnuPG, the GNU Privacy Guard.
http://www.adammil.net/
Copyright (C) 2008 Adam Milazzo

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using AdamMil.Security.PGP;

namespace GPGDesktop
{

/// <summary>A cache that holds associates passwords with secret keys for a short period of time. The password cache
/// uses a background thread to clear expired passwords, so the cache should be disposed when you are done with it in
/// order to terminate this thread.
/// </summary>
public class PasswordCache : IDisposable
{
  public PasswordCache()
  {
    quitEvent = new ManualResetEvent(false);
    thread    = new Thread(ThreadFunc);
    thread.Start();
  }

  ~PasswordCache() { Dispose(true); }

  /// <summary>Gets or sets the number of seconds for which a password is held in the cache. A value of zero will cause
  /// passwords to never expire.
  /// </summary>
  public int CacheTime
  {
    get { return (int)cacheTime.TotalSeconds; }
    set
    {
      int previousTime = CacheTime;
      if(value != previousTime)
      {
        if(value < 0) throw new ArgumentOutOfRangeException();
        cacheTime    = new TimeSpan(0, 0, value);
        noExpiration = value == 0;

        if(!noExpiration && previousTime == 0 || value < previousTime) // if the cache time was reduced
        {
          DateTime cutoff = NewExpirationTime;
          lock(cache) // make sure no password stays around longer than the new expiration time
          {
            foreach(KeyValuePair<string, CacheEntry> pair in cache)
            {
              if(pair.Value.Expiration > cutoff) pair.Value.Expiration = cutoff;
            }
          }
        }
      }
    }
  }

  /// <summary>Adds a new password to the cache for the given key ID.</summary>
  /// <param name="keyId">The ID of the key whose password is given.</param>
  /// <param name="password">The password of the key. The password will be owned and disposed by the cache, so make a
  /// copy first if you need it.
  /// </param>
  /// <param name="transient">If true, the password will only be held for a short time, regardless of the
  /// <see cref="CacheTime"/>. This can be used to cache the password for a few seconds so that the user doesn't have
  /// to enter the password during every step of a multi-step PGP operation, even if the user requests that his
  /// password not be remembered.
  /// </param>
  public void Add(string keyId, SecureString password, bool transient)
  {
    if(keyId == null || password == null) throw new ArgumentNullException();

    DateTime expiration = transient && CacheTime > 10 ? DateTime.Now.AddSeconds(10) : NewExpirationTime;
    lock(cache)
    {
      CacheEntry entry;
      if(cache.TryGetValue(keyId, out entry))
      {
        if(expiration > entry.Expiration) entry.Expiration = expiration;
        entry.Password.Dispose();
        entry.Password = password;
      }
      else
      {
        cache[keyId] = new CacheEntry(password, expiration);
      }
    }
  }

  public void Dispose()
  {
    GC.SuppressFinalize(this);
    Dispose(false);
  }

  /// <summary>Retrieves the password for the given key, or null if the password could not be found. The password
  /// returned is a copy, and should be disposed by the caller.
  /// </summary>
  /// <param name="keyId">The ID of the key whose password is sought.</param>
  /// <param name="refresh">If true, the expiration time of the password will be extended.</param>
  public SecureString Get(string keyId, bool refresh)
  {
    if(keyId == null) throw new ArgumentNullException();

    CacheEntry entry;
    lock(cache)
    {
      if(cache.TryGetValue(keyId, out entry))
      {
        if(entry.IsExpired)
        {
          cache.Remove(keyId);
          entry.Password.Dispose();
          entry = null;
        }
        else if(refresh)
        {
          entry.Expiration = NewExpirationTime;
        }
      }
    }
    return entry == null ? null : entry.Password.Copy();
  }

  /// <summary>Removes the password for the given key from the cache.</summary>
  public void Remove(string keyId)
  {
    if(keyId == null) throw new ArgumentNullException();

    lock(cache)
    {
      CacheEntry entry;
      if(cache.TryGetValue(keyId, out entry))
      {
        cache.Remove(keyId);
        entry.Password.Dispose();
      }
    }
  }

  protected virtual void Dispose(bool finalizing)
  {
    if(thread != null)
    {
      quitEvent.Set();
      if(!thread.Join(250)) thread.Abort();
      quitEvent.Close();
      thread    = null;
      quitEvent = null;
    }
  }

  sealed class CacheEntry
  {
    public CacheEntry(SecureString password, DateTime expiration)
    {
      if(password == null) throw new ArgumentNullException();
      Password   = password;
      Expiration = expiration;
    }

    public bool IsExpired
    {
      get { return Expiration <= DateTime.Now; }
    }

    public SecureString Password;
    public DateTime Expiration;
  }

  /// <summary>Gets a new expiration time, counting from the current moment.</summary>
  DateTime NewExpirationTime
  {
    get { return noExpiration ? DateTime.MaxValue : DateTime.Now + cacheTime; }
  }

  /// <summary>Removes cache entries with expired passwords.</summary>
  void ClearExpiredPasswords()
  {
    lock(cache)
    {
      foreach(string id in new List<string>(cache.Keys))
      {
        CacheEntry entry = cache[id];
        if(entry.IsExpired)
        {
          cache.Remove(id);
          entry.Password.Dispose();
        }
      }
    }
  }

  /// <summary>Removes expired passwords every so often.</summary>
  void ThreadFunc()
  {
    while(!quitEvent.WaitOne(30000, false)) ClearExpiredPasswords(); // clear expired passwords every 30 seconds
  }

  readonly Dictionary<string, CacheEntry> cache = new Dictionary<string, CacheEntry>();
  Thread thread;
  ManualResetEvent quitEvent;
  TimeSpan cacheTime = new TimeSpan(0, 5, 0); // 5 minute cache time
  bool noExpiration;
}

} // namespace GPGDesktop