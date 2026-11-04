using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterProject.Models
{
    public class Counter
    {
        public string Name { get; set; }
        public int StartCount { get; set; } = 0;

        public string HeaderText => "Dodaj swój licznik";
        public string NameTextEditorPlaceholder => "Wpisz swoją nazwę licznika";
        public string NumTextEditorPlaceholder => "Wpisz początkową wartość licznika(pole może puste, wtedy początkową wartością będzie 0)";
        public string CreateCounterButtonText => "Dodaj nowy licznik";
        public string AddCounterTextButton => "Add";
        public string AddTextButton => "+";
        public string SubTextButton => "-";
        public string DefaultCounterName => "Counter";
        public string DefaultCounterStartCount => "0";
    }
}
