namespace MauiAddreessApp8.ClassLibrary.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string StreetAddress { get; set; }
        public string? StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public string CityStateZip => $"{City}, {State} {PostalCode}";
    }
}
