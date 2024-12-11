using MauiAddreessApp8.ClassLibrary.Models;
using MauiAddreessApp8.ClassLibrary.Dtos;

namespace MauiAddressApp8.Mobile.Services.Interfaces
{
    public interface IAddressClient
    {
        Task<GetAddressesResponseDTO> GetAddresses();
        Task<GetAddressResponseDTO> GetAddress(Guid id);

        Task<Result> AddAddress(GetAddressResponseDTO addressDTO);

        Task<Result> UpdateAddress(GetAddressResponseDTO addressDTO);
        Task<Result> DeleteAddress(Guid id);

    }
}
