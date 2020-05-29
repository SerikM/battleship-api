using System;
using battleship.Models;
using Microsoft.Extensions.Caching.Memory;

namespace battleship.Repositories
{
    public class MockRepository : IMockRepository
    {
        private IMemoryCache _cache;

        public MockRepository(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public Battlefield GetCurrentBattlefield()
        {
            Battlefield cacheEntry;
            _cache.TryGetValue("battlefield", out cacheEntry);
            return cacheEntry;
        }

        public void SetBattleField(Battlefield battlefield)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(3));
            _cache.Set("battlefield", battlefield, cacheEntryOptions);
        }
    }
}
