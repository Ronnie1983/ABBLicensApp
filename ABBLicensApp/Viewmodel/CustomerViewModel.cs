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
using Newtonsoft.Json;
using Licens = ABBLicensApp.Model.Licens;

namespace ABBLicensApp.Viewmodel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _activeLicenses = new ObservableCollection<string>();
        private ObservableCollection<Licens> _filteredLicenses = new ObservableCollection<Licens>();
        private string _newNote;
        private string _selectedNote;
        private Customer _customer;

        public CustomerViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoBack = new RelayCommand(BackBtn);
            AddBtn = new RelayCommand(AddComment);
            DeleteNote = new RelayCommand(DeleteNoteBtn);
            Customer = Shared.SelectedCustomer;
            
        }


        public RelayCommand DeleteNote { get; set; }

        private void DeleteNoteBtn()
        {
            Customer.Notes.Remove(SelectedNote);
        }

        //public ObservableCollection<Licens> FilteredLicenses
        //{
        //    get
        //    {
        //        foreach (var p in Shared.Products)
        //        {
                    
        //        }
        //    }
        //    set
        //    {
        //        if (Equals(value, _filteredLicenses)) return;
        //        _filteredLicenses = value;
        //        OnPropertyChanged();
        //    }
        //}

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
            get => _customer;
            set
            {
                if (Equals(value, _customer)) return;
                _customer = value;

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
