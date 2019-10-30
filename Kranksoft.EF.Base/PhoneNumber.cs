using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Kranksoft.EF.Base
{
    /// <summary>
    /// A PhoneNumber for a Party with a PhoneType and a Number.
    /// </summary>
    public class PhoneNumber : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string number;
        private string phoneType;
        private Party party;
        #endregion

        #region Properties
        [ScaffoldColumn(false), Editable(false)]
        public int Id { get => id; protected set => SetPropertyValue(ref id, value); }
        [MaxLength(15), DataType(DataType.PhoneNumber)]
        public string Number { get => number; set => SetPropertyValue(ref number, value); }
        public string PhoneType { get => phoneType; set => SetPropertyValue(ref phoneType, value); }
        public Party Party { get => party; set => SetReferencePropertyValue(ref party, value); }
        #endregion

        public override string ToString() => Number;

        #region INotifyPropertyChanged
        private PropertyChangedEventHandler propertyChanged;
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
}

