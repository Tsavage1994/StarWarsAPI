using StarWarsAPI.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public class StarWarsClient
    {
        private readonly HttpClient _client;

        public StarWarsClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<PeopleResponseModel> GetPersonID(string id)
        {
            return await GetAsync<PeopleResponseModel>($"/api/people/{id}");
        }
        public async Task<PlanetResponseModel> GetPlanetID(string id)
        {
            return await GetAsync <PlanetResponseModel> ($"/api/planets/{id}");
        }
        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Star Wars API returned bad response");
            }
        }
    }
}
