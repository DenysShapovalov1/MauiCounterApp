using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterProject.Models
{
    internal class AllCounters
    {
        public ObservableCollection<Counter> counters { get; set; } = new ObservableCollection<Counter>();


        public static AllCounters Instance { get; } = new AllCounters();
    }
}
