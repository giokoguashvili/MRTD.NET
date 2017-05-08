using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities.IO;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class Cache<TResult> : ICache<TResult>
    {
        private readonly Func<TResult> _functForCache;

        private TResult _cachedData;

        public Cache(Func<TResult> functForCache)
        {
            _functForCache = functForCache;
        }
        public TResult Content()
        {
            if (_cachedData == null)
            {
                _cachedData = _functForCache();
            }
            return _cachedData;
        }
    }

    public class Cache<TInput, TResult> : ICache<TInput, TResult>
    {
        private readonly Func<TInput, TResult> _functForCache;

        private TResult _cachedData;

        public Cache(Func<TInput, TResult> functForCache)
        {
            _functForCache = functForCache;
        }
        public TResult Content(TInput input)
        {
            if (_cachedData == null)
            {
                _cachedData = _functForCache(input);
            }
            return _cachedData;
        }
    }
}
