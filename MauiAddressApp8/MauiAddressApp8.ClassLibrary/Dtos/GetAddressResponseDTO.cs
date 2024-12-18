namespace MauiAddressApp8.ClassLibrary.Dtos
{
    public class GetAddressResponseDTO
    {
        public GetAddressResponseDTO()
        {
            Address = new AddressDTO();
        }

        public AddressDTO Address { get; set; }

    }
}
