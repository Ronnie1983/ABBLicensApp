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
    public class CustomerViewModel : ViewModel
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
            GoBack = new GoBackCommand();
            AddBtn = new RelayCommand(AddCommentAndEmptyNewNote);
            DeleteNoteBtn = new RelayCommand(DeleteSelectedNote);
            GoToHomepage = new GoToPageCommand("LoginSucceed");
            EditBtn = new GoToPageCommand("EditCustomer");
            Customer = Shared.SelectedCustomer;
            ConnectLicenseBtn = new GoToPageCommand("ConnectNewLicens");
            GoToEditLicense = new RelayCommand(UpdatedSelectedLicensAndGoToEditLicense);
            SelectedLicens = null;
            SelectedProduct = null;
        }


        //Metoder
        public void AddCommentAndEmptyNewNote()
        {
            if (NewNote.Length > 0)
            {
                Customer.Notes.Add(NewNote);
                NewNote = "";
            }
        }

        private void DeleteSelectedNote()
        {
            Customer.Notes.Remove(SelectedNote);
        }


        private void UpdatedSelectedLicensAndGoToEditLicense()
        {
            //TODO pass selectedproduct to editlicens page

            if (SelectedProduct != null)
            {
                SelectedLicens = (Licens)SelectedProduct;
                Navigation.GoToPage("EditLicens");
            }
        }

        //Properties
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


        public string NewNote
        {
            get => _newNote ?? ""; //Hvis newNote == null så sæt dens værdi til ""
            set
            {
                SetProperty<string>(ref _newNote, value);
            }
        }

        public Licens SelectedLicens
        {
            get => Shared.SelectedLicens;
            set => Shared.SelectedLicens = value;
        }

        
        public Customer Customer
        {
            get => Shared.SelectedCustomer;
            set
            {
                Customer customer = Shared.SelectedCustomer;
                SetProperty<Customer>(ref customer, value);
            }
        }
        public RelayCommand GoBack { get; set; }
        public StaticClassSingleton Shared { get; }
        public RelayCommand AddBtn { get; set; }
        public RelayCommand DeleteNoteBtn { get; set; }
        public RelayCommand GoToEditLicense { get; set; }
        public RelayCommand EditBtn { get; set; }
        public RelayCommand ConnectLicenseBtn { get; set; }
        public RelayCommand GoToHomepage { get; set; }
    }
}
