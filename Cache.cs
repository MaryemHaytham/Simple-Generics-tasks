using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Cache<TKey, TValue>
    {
        private readonly int _maxSize;
        private readonly Dictionary<TKey, TValue> _cache;
        private readonly LinkedList<TKey> _lruList; 

        public Cache(int maxSize)
        {
            if (maxSize <= 0)
                throw new ArgumentException("Cache size must be greater than zero.");

            _maxSize = maxSize;
            _cache = new Dictionary<TKey, TValue>();
            _lruList = new LinkedList<TKey>();
        }

        public void Add(TKey key, TValue value)
        {
            if (_cache.ContainsKey(key))
            {
                _lruList.Remove(key);
                _lruList.AddFirst(key);
                _cache[key] = value;
            }
            else
            {
                if (_cache.Count >= _maxSize)
                {
                    Evict();
                }
                _cache[key] = value;
                _lruList.AddFirst(key);
            }
        }

        public TValue Retrieve(TKey key)
        {
            if (_cache.ContainsKey(key))
            {
                _lruList.Remove(key);
                _lruList.AddFirst(key);
                return _cache[key];
            }

            throw new KeyNotFoundException("Key not found in the cache.");
        }

        public void Remove(TKey key)
        {
            if (_cache.ContainsKey(key))
            {
                _cache.Remove(key);
                _lruList.Remove(key);
            }
        }

        private void Evict()
        {
            TKey leastUsedKey = _lruList.Last.Value;
            _lruList.RemoveLast();
            _cache.Remove(leastUsedKey);
        }
    }
}
