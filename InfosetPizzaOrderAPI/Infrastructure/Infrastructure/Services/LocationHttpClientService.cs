using Application.Dtos.Location;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class LocationHttpClientService : ILocationHttpClientService
    {
        readonly HttpClient _httpClient;

        readonly string IPStackApiAccessKey;
        public LocationHttpClientService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration.GetSection("IPStack")["BaseURL"].ToString());
            IPStackApiAccessKey = configuration.GetSection("IPStack")["AccessKey"].ToString();
        }

        /*
        Kullanıcının IP adresi ile http://api.ipstack.com a istek atarak lokasyon bilgisini elde ediyoruz.  
        Get user location by sending request to http://api.ipstack.com with user IP address.
        https://ipstack.com/documentation

        IPStack'ten gelen response için kontrol yapılabilir !!
        */
        public async Task<Location> GetLocationFromIPStackAsync(string ipAddress)
        {
            string requestURL = $"{ipAddress}?access_key={this.IPStackApiAccessKey}";
            HttpResponseMessage response = await _httpClient.GetAsync(requestURL);
            string json = await response.Content.ReadAsStringAsync();
            Location? location = JsonConvert.DeserializeObject<Location>(json);

            return location;
        }
    }
}
