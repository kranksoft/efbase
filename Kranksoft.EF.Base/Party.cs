using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Kranksoft.EF.Base
{
    /// <summary>
    /// A Party is an abstract entity with an integer id, a photo, address1 and address2, and phonenumbers.
    /// Can be used as a baseclass for persons, companies and organizations etc.
    /// </summary>
    public abstract class Party : INotifyPropertyChanged
    {
        #region Fields
        private PropertyChangedEventHandler _propertyChanged;
        private int _id;
        private byte[] _photo;
        private Address _address1;
        private Address _address2;
        private readonly IList<PhoneNumber> _phoneNumbers = new List<PhoneNumber>(3);
        #endregion

        #region Properties
        /// <summary>
        /// Gets or protected sets a Party's Id.
        /// </summary>
        [ScaffoldColumn(false), Editable(false)]
        public int Id { get => _id; protected set => SetPropertyValue(ref _id, value); }
        /// <summary>
        /// Gets or sets a Party's Photo.
        /// </summary>
        public byte[] Photo { get => _photo; set => SetReferencePropertyValue(ref _photo, value); }
        /// <summary>
        /// Gets or sets a Party's Address 1
        /// </summary>
        public Address Address1 { get => _address1; set => SetReferencePropertyValue(ref _address1, value); }
        /// <summary>
        /// Gets or sets a Party's Address 2
        /// </summary>
        public Address Address2 { get => _address2; set => SetReferencePropertyValue(ref _address2, value); }
        /// <summary>
        /// Gets a Party's phone numbers.
        /// </summary>
        public IList<PhoneNumber> PhoneNumbers => _phoneNumbers;
        /// <summary>
        /// Gets a Party's display name.
        /// </summary>
        [NotMapped]
        public abstract string DisplayName { get; }
        #endregion

        #region INotifyPropertyChanged
        protected bool SetPropertyValue<T>(ref T propertyValue, T newValue, [CallerMemberName]string propertyName = null) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(propertyValue, newValue))
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected bool SetPropertyValue<T>(ref T? propertyValue, T? newValue, [CallerMemberName]string propertyName = null) where T : struct
        {
            if (EqualityComparer<T?>.Default.Equals(propertyValue, newValue))
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected bool SetPropertyValue(ref string propertyValue, string newValue, [CallerMemberName]string propertyName = null)
        {
            if (propertyValue == newValue)
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected bool SetReferencePropertyValue<T>(ref T propertyValue, T newValue, [CallerMemberName]string propertyName = null) where T : class
        {
            if (propertyValue == newValue)
            {
                return false;
            }
            propertyValue = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        private void OnPropertyChanged(string propertyName)
        {
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }
        #endregion
    }
}

