using System;
using System.Net.Http;
using System.Text.Json;
using ConfigurationExample.ServiceContracts;

namespace ConfigurationExample.Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _congifuration;


        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration congifuration)
        {
            _httpClientFactory = httpClientFactory;
            _congifuration = congifuration;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_congifuration["FinnhubToken"]}"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();

                Dictionary<string, object> responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary == null)
                {
                    throw new InvalidOperationException("No response from Finnhub server");
                };

                if (responseDictionary.ContainsKey("error"))
                {
                    throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
                };

                return responseDictionary;
            };
        }
    }
}

