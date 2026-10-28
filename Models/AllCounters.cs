using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterProject.Models
{
    internal class AllCounters
    {
        public List<Counter> counters = new();

        public static AllCounters Instance { get; } = new AllCounters();
    }
}
