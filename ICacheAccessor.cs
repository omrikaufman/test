using System;
using System.Threading.Tasks;

namespace MuntersGIPHY
{
    public abstract class ICacheAccessor
    {
        public abstract T Get<T>(string itemId, Func<T> getter, TimeSpan? slidingExpiration = null) where T : class;
        public abstract T GetValue<T>(string itemId, Func<T> getter, TimeSpan? slidingExpiration = null) where T : struct;
        public abstract Task<T> GetAsync<T>(string itemId, Func<Task<T>> getter, TimeSpan? slidingExpiration = null) where T : class;
        public abstract Task<T> GetValueAsync<T>(string itemId, Func<Task<T>> getter, TimeSpan? slidingExpiration = null) where T : struct;
        public abstract T Get<T>(string itemId, string cacheContext, Func<T> getter, TimeSpan? slidingExpiration = null) where T : class;
        public abstract T GetValue<T>(string itemId, string cacheContext, Func<T> getter, TimeSpan? slidingExpiration = null) where T : struct;
        public abstract Task<T> GetAsync<T>(string itemId, string cacheContext, Func<Task<T>> getter, TimeSpan? slidingExpiration = null) where T : class;
        public abstract Task<T> GetValueAsync<T>(string itemId, string cacheContext, Func<Task<T>> getter, TimeSpan? slidingExpiration = null) where T : struct;
    }
}