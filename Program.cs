using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MuntersGIPHY;
using MuntersGIPHY.Requests;
using Newtonsoft.Json;

namespace MuntersGIPHY
{
    class Program
    {
      

        //this in the future will be a web application so the main oage will change 
        // it can be also a win form application 
        //it beeing written in a consol application due to time frames
        static async Task Main(string[] args)
        {

            var _cache = new CacheGiphy();
        var apiKey = "Et1mg38eAxAup2oJU61RT7Tvilu0v1Me";

            Console.WriteLine("Please type Trending If you Would Like to See ALl the url Trending");
    
        var line = Console.ReadLine().ToLower();
            ServiceTypeEnum typeService = (ServiceTypeEnum) 0;
            switch (line)
            {
                case "1":
                    typeService = ServiceTypeEnum.Trending;
                    break;
                case "2":
                    Console.WriteLine("Search");
                    typeService = ServiceTypeEnum.Search;
                    break;
                default:
                    System.Environment.Exit(1);
                    break;
            }

            var gimphyService = new GimphyService();
            if (typeService == ServiceTypeEnum.Trending)
            {
                var trendingResualts =await gimphyService.GetTrending(new GetTrendingRequest() { ApiKey = apiKey });
                foreach (var item in trendingResualts.Urls)
                {
                    Console.WriteLine(item);

                }
                Console.WriteLine("click 0 to go to main menu");
                var userChoose1 = Console.ReadLine();
                if (userChoose1 == "0")
                {
                    Console.Clear();
                    await Main(args);
                }
                else
                {
                    System.Environment.Exit(1);
                }
            }


            if (typeService == ServiceTypeEnum.Search)
            {
                await Search(gimphyService, apiKey, _cache);

                Console.WriteLine("For another Search Type 1 go back to main Page type 0 ");
                var userChoose = Console.ReadLine();

                if (userChoose == "1")
                {
                    await Search(gimphyService, apiKey, _cache);
                }
                else
                {
                    Console.Clear();
                    await Main(args);
                }
            }




           

        }

        private static async Task Search(GimphyService gimphyService, string apiKey, CacheGiphy _cache)
        { 
         
        Console.WriteLine("Please Type you Desire Search Word ");
            var wordToSearch = Console.ReadLine();

            
            //TODO   need to finish cache implimitation with DB 
             //wordToSearch = _cache.GetOrCreate(wordToSearch);


            var trendingResualts = await gimphyService.GimphySerach(new GetSearchRequest() {ApiKey = apiKey,SearchWord = wordToSearch });
            foreach (var item in trendingResualts.Items)
            {

                using (StreamWriter writetext =
                            new StreamWriter(
                                "C:\\searchresults.html",
                                true))
                {

                    writetext.WriteLine($"<h1><a href='{ item.bitly_gif_url}'>{item.title}</a></h1>");
                    
                        
                }

               
            }
            Console.WriteLine("Location of the file is here C:\\searchresults.html");
        }
    }
}
