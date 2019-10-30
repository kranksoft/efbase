using System.Collections.Generic;

namespace Kranksoft.EF.Base
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostal { get; set; }
        public Country Country { get; set; }
        public IList<Party> Parties { get; } = new List<Party>();
    }
}

