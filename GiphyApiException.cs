using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MuntersGIPHY
{
    public class GiphyApiException : Exception
    {

        public GiphyApiException(HttpStatusCode statusCode, string message, Exception innerException = null)
        {
            StatusCode = statusCode;
            Message = message;

        }
        // Summary:
        //     Status code of response from Egnyte API
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }


    }
}