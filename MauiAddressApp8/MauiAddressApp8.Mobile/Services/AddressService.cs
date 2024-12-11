using MauiAddressApp8.Mobile.Services.Interfaces;
using MauiAddreessApp8.ClassLibrary.Models;
using MauiAddreessApp8.ClassLibrary.Dtos;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace MauiAddressApp8.Mobile.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;
        public IConfiguration _configuration { get; }

        public AddressService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri("https://localhost:5001/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<GetAddressesResponseDTO> GetAddresses()
        {
            return await _httpClient.GetFromJsonAsync<GetAddressesResponseDTO>("api/Addresses");
        }

        public async Task<GetAddressResponseDTO> GetAddress(Guid id) => await _httpClient.GetFromJsonAsync<GetAddressResponseDTO>($"api/addresses/{id}");

        public async Task<Result> AddAddress(GetAddressResponseDTO addressDTO)
        {
            Result resultDTO = new Result();
            StringContent? content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            using HttpResponseMessage? response = await _httpClient.PostAsync("api/addresses", content);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<Result> UpdateAddress(GetAddressResponseDTO addressDTO)
        {
            Result resultDTO = new Result();
            StringContent? content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            //using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<Result> DeleteAddress(Guid id)
        {
            Result resultDTO = new Result();


            using HttpResponseMessage? response = await _httpClient.DeleteAsync("api/addresses" + id);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }
    }
}
