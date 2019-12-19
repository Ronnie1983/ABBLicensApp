using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.View;
using Customer = ABBLicensApp.Model.Customer;
using Licens = ABBLicensApp.Model.Licens;

namespace ABBLicensApp.Viewmodel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _activeLicenses = new ObservableCollection<string>();
        private ObservableCollection<Product> _filteredLicenses = new ObservableCollection<Product>();
        //private Product _selectedProduct;
        private string _selectedSupplier;
        private string _newNote;
        private string _selectedNote;
      

        public CustomerViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoBack = new RelayCommand(BackBtn);
            AddBtn = new RelayCommand(AddComment);
            DeleteNote = new RelayCommand(DeleteNoteBtn);
            GoToHomepage = new RelayCommand(GoHome);
            EditBtn = new RelayCommand(Edit);
            Customer = Shared.SelectedCustomer;
            ConnectLicenseBtn = new RelayCommand(GoToAddLicense);
            GoToEditLicense = new RelayCommand(EditLicens);
            SelectedLicens = null;
            SelectedProduct = null;
        }

        public RelayCommand GoToEditLicense { get; set; }

        public RelayCommand EditBtn { get; set; }

        public RelayCommand ConnectLicenseBtn { get; set; }

        public RelayCommand GoToHomepage { get; set; }

        public Product SelectedProduct
        {
            get => Shared.SelectedProduct;
            set
            {
                if (Equals(value,Shared.SelectedProduct)) return;
                Shared.SelectedProduct = value;
                OnPropertyChanged();
            }
        }

        public string SelectedSupplier
        {
            get => _selectedSupplier;
            set
            {
                if (value == _selectedSupplier) return;
                _selectedSupplier = value;
                OnPropertyChanged();
                FilteredLicenses.Clear();
                OnPropertyChanged(nameof(FilteredLicenses));
            }
        }

        public RelayCommand DeleteNote { get; set; }

        public ObservableCollection<Product> FilteredLicenses
        {
            get
            {

                foreach (Product p in Shared.Products)
                {
                    if (p.Customer.CompanyName == Customer.CompanyName && p.Supplier.Name == SelectedSupplier)
                    {
                        _filteredLicenses.Add(p);
                    }
                }

                return _filteredLicenses;
            }
            set
            {
                if (Equals(value, _filteredLicenses)) return;
                _filteredLicenses = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ActiveLicenses
        {
            get
            {
                foreach (Product p in Shared.Products)
                {
                    if (p.Customer.CompanyName == Customer.CompanyName && !_activeLicenses.Contains(p.Supplier.Name))
                    {
                        _activeLicenses.Add(p.Supplier.Name);
                    }
                        
                }

                return _activeLicenses;
            }
            set
            {
                if (Equals(value, _activeLicenses)) return;
                _activeLicenses = value;
                OnPropertyChanged();
            }
        }

        public string SelectedNote
        {
            get => _selectedNote;
            set
            {
                if (value == _selectedNote) return;
                _selectedNote = value;
            }
        }

        public RelayCommand AddBtn { get; set; }

        public string NewNote
        {
            get => _newNote ?? ""; //Hvis newNote == null så sæt dens værdi til ""
            set
            {
                if (value == _newNote) return;
                _newNote = value;
                OnPropertyChanged();
            }
        }

        public Licens SelectedLicens
        {
            get => Shared.SelectedLicens;
            set => Shared.SelectedLicens = value;
        }

        public RelayCommand GoBack { get; set; }

        public StaticClassSingleton Shared { get; }

        public Customer Customer
        {
            get => Shared.SelectedCustomer;
            set
            {
                if (Equals(value, Shared.SelectedCustomer)) return;
                Shared.SelectedCustomer = value;
                OnPropertyChanged();

            }
        }

        public void AddComment()
        {
            if (NewNote.Length > 0)
            {
                Customer.Notes.Add(NewNote);
                NewNote = "";
            }
        }

        private void Edit()
        {
            Navigation.GoToPage("EditCustomer");
        }

        private void BackBtn()
        {
            Navigation.GoBack();
        }

        private void DeleteNoteBtn()
        {
            Customer.Notes.Remove(SelectedNote);
        }

        private void GoHome()
        {
            Navigation.GoToPage("LoginSucceed");
        }

        private void GoToAddLicense()
        {
            Navigation.GoToPage("ConnectNewLicens");
        }

        private void EditLicens()
        {
            if (SelectedProduct != null)
            {
                SelectedLicens = (Licens) SelectedProduct;
                Navigation.GoToPage("EditLicens");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
