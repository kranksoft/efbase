using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kranksoft.EF.Base
{
    public abstract class Party : Entity<int>
    {
        public byte[] Photo { get; set; }
        public Address Address1 { get; set; }
        public IList<PhoneNumber> PhoneNumbers { get; } = new List<PhoneNumber>(3);
        [NotMapped]
        public abstract string DisplayName { get; }
        public override string ToString()
        {
            return DisplayName;
        }
    }
}

