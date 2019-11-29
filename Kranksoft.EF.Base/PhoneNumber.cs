using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Kranksoft.EF.Base
{
    /// <summary>
    /// A PhoneNumber owned by a Party.
    /// </summary>
    public class PhoneNumber : INotifyPropertyChanged
    {
        #region Fields
        private int _id;
        private string _number;
        private PhoneType _phoneType;
        private Party _party;
        #endregion

        #region Properties
        [ScaffoldColumn(false), Editable(false)]
        public int Id { get => _id; protected set => SetPropertyValue(ref _id, value); }
        [MaxLength(15), DataType(DataType.PhoneNumber)]
        public string Number { get => _number; set => SetPropertyValue(ref _number, value); }
        [EnumDataType(typeof(PhoneType))]
        public PhoneType PhoneType { get => _phoneType; set => SetPropertyValue(ref _phoneType, value); }
        public Party Party { get => _party; set => SetReferencePropertyValue(ref _party, value); }
        #endregion

        public override string ToString()
        {
            return Number;
        }

        #region INotifyPropertyChanged
        protected PropertyChangedEventHandler propertyChanged;
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
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { propertyChanged += value; }
            remove { propertyChanged -= value; }
        }
        #endregion
    }

    public enum PhoneType
    {
        Mobile,
        LandLine,
        Satelite
    }
}

