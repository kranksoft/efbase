using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Kranksoft.EF.Base
{

    public class Address : INotifyPropertyChanged
    {
        #region Fields
        private PropertyChangedEventHandler _propertyChanged;
        private int _id;
        private string _street;
        private string _city;
        private string _zipPostal;
        private string _stateProvince;
        private Country _country;
        private IList<Party> _parties1 = new List<Party>();
        private IList<Party> _parties2 = new List<Party>();
        #endregion

        #region Properties
        [ScaffoldColumn(false), Editable(false)]
        public int Id { get => _id; protected set => SetPropertyValue(ref _id, value); }
        public string Street { get => _street; set => SetPropertyValue(ref _street, value); }
        public string City { get => _city; set => SetPropertyValue(ref _city, value); }
        public string StateProvince { get => _stateProvince; set => SetPropertyValue(ref _stateProvince, value); }
        public string ZipPostal { get => _zipPostal; set => SetPropertyValue(ref _zipPostal, value); }
        public Country Country { get => _country; set => SetReferencePropertyValue(ref _country, value); }
        public IList<Party> Parties1 { get => _parties1; set => SetReferencePropertyValue(ref _parties1, value); }
        public IList<Party> Parties2 { get => _parties2; set => SetReferencePropertyValue(ref _parties2, value); }
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