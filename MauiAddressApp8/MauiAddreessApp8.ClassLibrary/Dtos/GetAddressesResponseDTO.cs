namespace MauiAddreessApp8.ClassLibrary.Dtos
{
    public class GetAddressesResponseDTO
    {
        public GetAddressesResponseDTO()
        {
            AddressList = new List<AddressDTO>();
        }
        public List<AddressDTO> AddressList { get; set; }
    }
}
