using ABBLicensApp.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ABBLicensApp.Model
{
    public class Supplier : INotifyPropertyChanged
    {
        private string _name;

        public Supplier(string name)
        {
            Name = name;
        }

        public Supplier()
        {
            Name = "Random";
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
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
