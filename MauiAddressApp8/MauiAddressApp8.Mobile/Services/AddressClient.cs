using MauiAddreessApp8.ClassLibrary.Dtos;
using MauiAddreessApp8.ClassLibrary.Models;
using MauiAddressApp8.Mobile.Services.Interfaces;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MauiAddressApp8.Mobile.Services
{
    public class AddressClient : IAddressClient
    {
        private readonly HttpClient _httpClient;

        public AddressClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetAddressesResponseDTO> GetAddresses()
        {
            GetAddressesResponseDTO responseDto = new();
            HttpResponseMessage? response = await _httpClient.GetAsync("api/Addresses");
            response.EnsureSuccessStatusCode();

            if (response != null)
            {
                string content = await response.Content.ReadAsStringAsync();
                responseDto = JsonSerializer.Deserialize<GetAddressesResponseDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();
            }
            return responseDto;
        }

        public async Task<GetAddressResponseDTO> GetAddress(Guid id)
        {
            GetAddressResponseDTO responseDto = new();
            HttpResponseMessage? response = await _httpClient.GetAsync($"api/addresses/{id}");

            response.EnsureSuccessStatusCode();

            if (response != null)
            {
                string content = await response.Content.ReadAsStringAsync();
                responseDto = JsonSerializer.Deserialize<GetAddressResponseDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();
            }
            return responseDto;

        }

        public async Task<ResultModel> AddAddress(AddressModel address)
        {
            UpdateAddressRequestDTO requestDto = new();
            requestDto.Address = new AddressDTO
            {
                StreetAddress = address.StreetAddress,
                StreetAddress2 = address.StreetAddress2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode
            };
            ResultModel resultDTO = new ResultModel();
            StringContent? content = new StringContent(JsonSerializer.Serialize(requestDto), Encoding.UTF8, "application/json");
            using HttpResponseMessage? response = await _httpClient.PostAsync("api/addresses", content);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<ResultModel> UpdateAddress(AddressModel address)
        {
            UpdateAddressRequestDTO requestDto = new();
            requestDto.Address = new AddressDTO
            {
                Id = address.Id,
                StreetAddress = address.StreetAddress,
                StreetAddress2 = address.StreetAddress2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode
            };
            ResultModel resultDTO = new ResultModel();
            StringContent? content = new StringContent(JsonSerializer.Serialize(requestDto), Encoding.UTF8, "application/json");
            //using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<ResultModel> DeleteAddress(Guid id)
        {
            ResultModel resultDTO = new ResultModel();


            using HttpResponseMessage? response = await _httpClient.DeleteAsync("api/addresses" + id);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

    }
}
