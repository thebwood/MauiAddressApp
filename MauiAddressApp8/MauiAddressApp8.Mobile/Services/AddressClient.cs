using MauiAddressApp8.ClassLibrary.Dtos;
using MauiAddressApp8.ClassLibrary.Models;
using MauiAddressApp8.Mobile.Services.Interfaces;
using System.Net;
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

        public async Task<ResultModel> CreateAddress(AddressModel address)
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
            ResultModel result = new ResultModel();
            StringContent? content = new StringContent(JsonSerializer.Serialize(requestDto), Encoding.UTF8, "application/json");
            using HttpResponseMessage? response = await _httpClient.PostAsync("api/addresses", content);
            if (response != null)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<ResultModel>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new ResultModel();

                return result;
            }
            else
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                return result;
            }
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
            ResultModel result = new ResultModel();
            StringContent? content = new StringContent(JsonSerializer.Serialize(requestDto), Encoding.UTF8, "application/json");
            HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            if (response != null)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<ResultModel>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new ResultModel();

                return result;
            }
            else
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                return result;
            }
        }


        public async Task<ResultModel> DeleteAddress(Guid id)
        {
            ResultModel result = new ResultModel();


            using HttpResponseMessage? response = await _httpClient.DeleteAsync("api/addresses" + id);

            if (response != null)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<ResultModel>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new ResultModel();

                return result;
            }
            else
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                return result;
            }
        }

    }
}
