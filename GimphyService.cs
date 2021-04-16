using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MuntersGIPHY.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MuntersGIPHY
{
    public  class GimphyService : IGimphyService
    {


        //public  GimphyServiceAutorize()
        //{

        //}

        public  async Task<GetTrendingResponse> GetTrending(GetTrendingRequest request)
        {
            var limit = 25;
            //var count = 0;
            //var totalResault = 0;
            //var offset = 0;

            var allUrls = new List<string>();
            using (var client = new HttpClient())
            {

                //do
                //{
                var url = $"v1/gifs/trending?api_key={request.ApiKey}&limit={limit}";
                client.BaseAddress = new Uri($"https://api.giphy.com/");
                var response = await client.GetAsync(url);

                await ThrowOnHttpError(response);

                var json = JsonConvert.DeserializeObject<TrendingResults>(response.Content.ReadAsStringAsync().Result);


                foreach (var item in json.data)
                {
                    allUrls.Add(item.bitly_gif_url);
                }

                var res = new GetTrendingResponse()
                {
                    Urls = allUrls
                };


                return res;
                //TODo Pagination

                //} while (json.pagination.total_count != totalResault);

            }


        }

        public async Task<GetSearchResponse> GimphySerach(GetSearchRequest request)
        {
            var allItems =  new List<Datum>();
            ;
            using (var client = new HttpClient())
            {

                //do
                //{
                var url = $"v1/gifs/search?api_key={request.ApiKey}&q={request.SearchWord}&limit={request.Limit}";
                client.BaseAddress = new Uri($"https://api.giphy.com/");
                var response = await client.GetAsync(url);

                await ThrowOnHttpError(response);

                var json = JsonConvert.DeserializeObject<TrendingResults>(response.Content.ReadAsStringAsync().Result);


                foreach (var item in json.data)
                {
                    allItems.Add(item);
                }

                var res = new GetSearchResponse()
                {
                    Items = allItems
                };


                return res;
                //TODo Pagination

                //} while (json.pagination.total_count != totalResault);

            }


        }

        static async Task ThrowOnHttpError(HttpResponseMessage response, HttpStatusCode minErrorCode = HttpStatusCode.MultipleChoices)
        {
            if (response.StatusCode >= minErrorCode)
            {
                JObject jContent = null;
                string errorMessage;
                try
                {
                    jContent = JObject.Parse(await response.Content.ReadAsStringAsync());
                    errorMessage = jContent["errors"]?.ToString();
                }
                catch
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
                }


                var apiException = new Exception(response.StatusCode.ToString(), new Exception(errorMessage ?? jContent?.ToString()));


                foreach (var httpResponseHeader in response.Headers)
                {
                    apiException.Data.Add(httpResponseHeader.Key, httpResponseHeader.Value.FirstOrDefault());
                }

                throw apiException;
            }
        }
    }
}

