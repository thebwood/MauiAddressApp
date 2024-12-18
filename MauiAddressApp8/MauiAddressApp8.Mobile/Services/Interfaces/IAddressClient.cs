using MauiAddressApp8.ClassLibrary.Models;
using MauiAddressApp8.ClassLibrary.Dtos;

namespace MauiAddressApp8.Mobile.Services.Interfaces
{
    public interface IAddressClient
    {
        Task<GetAddressesResponseDTO> GetAddresses();
        Task<GetAddressResponseDTO> GetAddress(Guid id);
        Task<ResultModel> CreateAddress(AddressModel address);
        Task<ResultModel> UpdateAddress(AddressModel address);
        Task<ResultModel> DeleteAddress(Guid id);

    }
}
