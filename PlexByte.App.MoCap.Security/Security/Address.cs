namespace MoCap.Security
{
    public enum EAddressType { Work, Home, Office, Unknown };
    public class Address
    {
        public string Id { get; set; } = null;
        public string BuildingName { get; set; } = null;
        public string StreetName { get; set; } = null;
        public string StreetNumber { get; set; } = null;
        public string POBox { get; set; } = null;
        public string ZIP { get; set; } = null;
        public string City { get; set; } = null;
        public string County { get; set; } = null;
        public string State { get; set; } = null;
        public string Country { get; set; } = null;
        public EAddressType Type { get; set; } = EAddressType.Unknown;
        public bool IsPrivate { get; set; } = true;

        public Address() { }

        public Address(string pStreetName, string pStreetNumber, string pZIP, string pCity, string pState, string pCountry)
        {
            StreetName = pStreetName;
            StreetNumber = pStreetNumber;
            ZIP = pZIP;
            City = pCity;
            State = pState;
            Country = pCountry;
        }

        public Address(string pStreetName, string pStreetNumber, string pZIP, string pCity, string pState, string pCountry, EAddressType pType)
        {
            StreetName = pStreetName;
            StreetNumber = pStreetNumber;
            ZIP = pZIP;
            City = pCity;
            State = pState;
            Country = pCountry;
            Type = pType;
        }
    }
}
