using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MuntersGIPHY.Requests;

namespace MuntersGIPHY
{
    public interface IGimphyService
    {

        Task<GetTrendingResponse> GetTrending(GetTrendingRequest request);

        Task<GetSearchResponse> GimphySerach(GetSearchRequest request);
    }

 
}
