using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Caching;

namespace MuntersGIPHY
{
    public class CacheGiphy
    {
        static ObjectCache cache = MemoryCache.Default;

        public string GetOrCreate(string word)
        {
            string fileContents = (string) cache.Get(word);
            if (!string.IsNullOrEmpty(fileContents))
            {
                CacheItemPolicy policy = new CacheItemPolicy();

                //List<string> filePaths = new List<string>();
                //filePaths.Add("c:\\cache\\example.txt");

                //policy.ChangeMonitors.Add(new
                //    HostFileChangeMonitor(filePaths));

                cache.Set("fileCon", word, policy);
                return word;
            }
            else
            {
                return word;
            }
        }

    }
}


//using System.Collections.Generic;
//using Microsoft.Extensions.Caching.Memory;

//namespace MuntersGIPHY
//{
//    public class StringCacher
//    {
//        private IMemoryCache _cache;
//        public readonly Dictionary<string, string> StringCache;

//        public StringCacher()
//        {
//             _cache = memoryCache;
//        }

//        public string AddOrReuse(string stringToCache)
//        {
//            if (StringCache.ContainsKey(stringToCache))
//            {

//                StringCache[stringToCache] = stringToCache;
//            }
//            else
//            {
//                return stringToCache;
//            }
//            return StringCache[stringToCache];
//        }
//    }
//}