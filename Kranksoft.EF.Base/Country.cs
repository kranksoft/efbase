using System.Collections.Generic;

namespace Kranksoft.EF.Base
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public string IsoCode { get; set; }
        public long Population { get; set; }
        public int AreaKm2 { get; set; }
        public string GpdUsd { get; set; }
        public IList<Address> Addresses { get; } = new List<Address>();

        public override string ToString()
        {
            return Name;
        }
    }
}

