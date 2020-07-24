using HotelZ.Core.Provider.Interfaces;
using HotelZ.Core.Provider.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelZ.Core.Provider
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient _httpClient;

        public HttpClientProvider(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient();
        }

        
    }
}
