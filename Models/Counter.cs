using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CounterProject.Models
{
    public class Counter : INotifyPropertyChanged
    {
        private string name;
        private int startCount;
        private int currentCount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged();
            }
        }

        public int StartCount
        {
            get => startCount;
            set
            {
                if (startCount == value) return;

                startCount = value;
                currentCount = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentCount));
            }
        }

        public int CurrentCount
        {
            get => currentCount;
            set
            {
                if (currentCount == value) return;

                currentCount = value;
                OnPropertyChanged();
            }
        }

        public string HeaderText => "Dodaj swój licznik";
        public string NameTextEditorPlaceholder => "Wpisz swoją nazwę licznika";
        public string NumTextEditorPlaceholder => "Wpisz początkową wartość licznika";
        public string CreateCounterButtonText => "Dodaj nowy licznik";
        public string AddCounterTextButton => "Add";
        public string AddTextButton => "+";
        public string SubTextButton => "-";
        public string DefaultCounterName => "Counter";
        public string DefaultCounterStartCount => "0";

        private void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
