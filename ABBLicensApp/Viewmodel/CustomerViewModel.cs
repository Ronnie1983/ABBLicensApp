using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Windows.UI.Composition.Interactions;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using ABBLicensApp.View;
using Newtonsoft.Json;
using Customer = ABBLicensApp.Model.Customer;
using Licens = ABBLicensApp.Model.Licens;

namespace ABBLicensApp.Viewmodel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _activeLicenses = new ObservableCollection<string>();
        private ObservableCollection<Product> _filteredLicenses = new ObservableCollection<Product>();
        private Product _selectedProduct;
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
            RefreshBtn = new RelayCommand(Refresh);
            //SelectedSupplier = "Cisco";
            //Customer.Notes.Add("Hej");
            //Customer.Notes.Add("test");
        }

        public RelayCommand EditBtn { get; set; }

        private void Edit()
        {
            Navigation.GoToPage("EditCustomer");
        }

        public RelayCommand ConnectLicenseBtn { get; set; }

        private void GoToAddLicense()
        {
            Navigation.GoToPage("ConnectNewLicens");
        }

        public RelayCommand RefreshBtn { get; set; }

        private void Refresh()
        {
            FilteredLicenses.Clear();
            OnPropertyChanged(nameof(FilteredLicenses));
        }

        public RelayCommand GoToHomepage { get; set; }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (Equals(value, _selectedProduct)) return;
                _selectedProduct = value;
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
            }
        }

        private void GoHome()
        {
            Navigation.GoToPage("LoginSucceed");
        }


        public RelayCommand DeleteNote { get; set; }

        private void DeleteNoteBtn()
        {
            Customer.Notes.Remove(SelectedNote);
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

        public RelayCommand GoBack { get; set; }

        private void BackBtn()
        {
            Navigation.GoBack();
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
