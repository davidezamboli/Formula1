using MauiApp1.Models;
using System.Net.Http.Json;


namespace MauiApp1.Usings
{
    public class NetworkManager
    {
        static public NetworkManager Istance = new NetworkManager();
        string _baseUri = "https://ergast.com/api/f1/";
        private readonly HttpClient _httpClient;

        public NetworkManager()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUri) };
        }

        public async Task<List<Race>> GetRacesFromJsonAsync(string year)
        {
            var response = await _httpClient.GetFromJsonAsync<RaceRoot>($"{year}.json");
            
            return response.MRDataRace.RaceTable.Races;
        }

        public async Task<List<Driver>> GetDriverFromJsonAsync(string year)
        {
            var response = await _httpClient.GetFromJsonAsync<DriverRoot>($"{year}/drivers.json");

            return response.MRDataDriver.DriverTable.Drivers;
        }
    }
}
