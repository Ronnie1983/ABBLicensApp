using ABBLicensApp.Annotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ABBLicensApp.Model
{
    public class Customer : INotifyPropertyChanged
    {
        private string _companyName;
        private string _address;
        private string _email;
        //private int _id;
        private ObservableCollection<string> _notes;
        private string _phoneNumber;
        private string _contactName;

        public Customer(string companyName, string address, string email, string phoneNumber, string contactName)
        {
            _companyName = companyName;
            _address = address;
            _email = email;
            _notes = new ObservableCollection<string>();
            _phoneNumber = phoneNumber;
            _contactName = contactName;
        }

        public Customer(Customer c)
        {
            _companyName = c.CompanyName;
            _address = c.Address;
            _email = c.Email;
            _notes = c.Notes;
            _phoneNumber = c.PhoneNumber;
            _contactName = c.ContactName;
        }

        public Customer()
        {
        }

        public string CompanyName
        {
            get => _companyName;
            set => _companyName = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        //public int Id
        //{
        //    get => _id;
        //    set => _id = value;
        //}

        public ObservableCollection<string> Notes
        {
            get => _notes;
            set
            {
                if (Equals(value, _notes)) return;
                _notes = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }

        public string ContactName
        {
            get => _contactName;
            set => _contactName = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}