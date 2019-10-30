using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kranksoft.EF.Base
{
    public class Person : Party
    {
        [Required]
        [DisplayName("First name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string FirstMidName { get; set; }

        [Required]
        [DisplayName("Last name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Full name")]
        public string FullName => $"{FirstMidName} {LastName}";

        [DisplayName("Display name")]
        public override string DisplayName => FullName;
    }
}

