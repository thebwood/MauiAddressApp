using MauiAddressApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAddressApp.Services
{
    public class AddressService
    {
        HttpClient httpClient;
        List<Address> addresses;
        public AddressService()
        {
            httpClient = new HttpClient();
            addresses = new List<Address>();
        }

        public async Task<List<Address>> GetAddresses()
        {
            HttpResponseMessage? response = await httpClient.GetAsync("https://api.mauiaddressapp.com/addresses");
            if (response.IsSuccessStatusCode)
            {
                string? content = await response.Content.ReadAsStringAsync();
                addresses = JsonSerializer.Deserialize<List<Address>>(content);
            }
            return addresses;
        }
    }
}
