namespace VetDirectoryTool.Core.Parser.Model
{
    public readonly struct ParserFileModel
    {
        public string Name { get; }
        public string Address1 { get; }
        public string Address2 { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string Latitude { get; }
        public string Longitude { get; }
        public string StateCode { get; }
        public string CountryCode { get; }
        public string Distance { get; }
        public string Phone { get; }

        public ParserFileModel
            (string name, string address1,
            string address2, string city,
            string postalCode, string latitude,
            string longitude, string stateCode,
            string countryCode, string distance,
            string phone)
        {
            Name = name;
            Address1 = address1;
            Address2 = address2;
            City = city;
            PostalCode = postalCode;
            Latitude = latitude;
            Longitude = longitude;
            StateCode = stateCode;
            CountryCode = countryCode;
            Distance = distance;
            Phone = phone;
        }
    }
}
