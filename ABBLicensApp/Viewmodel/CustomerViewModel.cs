using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Customer.Notes.Add("Hej");
            Customer.Notes.Add("test");
        }


        public RelayCommand DeleteNote { get; set; }

        private void DeleteNoteBtn()
        {
            Customer.Notes.Remove(SelectedNote);
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
