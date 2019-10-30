using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kranksoft.EF.Base
{
    /// <summary>
    /// A Person is a human Party.
    /// </summary>
    public class Person : Party
    {
        #region Fields
        private string _firstMidName;
        private string _lastName;
        private DateTime? _birthday;
        private string _email;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a Person's first name.
        /// </summary>
        [Required, DisplayName("First name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string FirstMidName { get => _firstMidName; set => SetPropertyValue(ref _firstMidName, value); }

        /// <summary>
        /// Gets or sets a Person's last name.
        /// </summary>
        [Required,DisplayName("Last name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get => _lastName; set => SetPropertyValue(ref _lastName, value); }

        /// <summary>
        /// Gets or sets a Person's birthday.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get => _birthday; set => SetPropertyValue(ref _birthday, value); }

        /// <summary>
        /// Gets or sets a Person's email address.
        /// </summary>
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get => _email; set => SetPropertyValue(ref _email, value); }

        /// <summary>
        /// Gets a Person's full name.
        /// </summary>        
        [DisplayName("Full name")]
        public string FullName => $"{FirstMidName} {LastName}";

        /// <summary>
        /// Gets a Person's display name.
        /// </summary>
        [DisplayName("Display name")]
        public override string DisplayName => FullName;
        #endregion
    }
}

