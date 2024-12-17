using MauiAddreessApp8.ClassLibrary.Models;
using MauiAddreessApp8.ClassLibrary.Dtos;

namespace MauiAddressApp8.Mobile.Services.Interfaces
{
    public interface IAddressClient
    {
        Task<GetAddressesResponseDTO> GetAddresses();
        Task<GetAddressResponseDTO> GetAddress(Guid id);

        Task<ResultModel> AddAddress(AddressModel address);

        Task<ResultModel> UpdateAddress(AddressModel address);
        Task<ResultModel> DeleteAddress(Guid id);

    }
}
