using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MVC.Mediator
{
    public class MediatorService : IMediatorService
    {
        private readonly HttpClient _httpClient;

        public MediatorService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode(); 
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
        }
    }
}
