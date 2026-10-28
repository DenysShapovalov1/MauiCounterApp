using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Threading.Tasks;

namespace CounterProject.Models
{
    public static class CounterStorage
    {
        private static readonly string FilePath =
            Path.Combine(FileSystem.AppDataDirectory, "counters.xml");

        public static void SaveCounters(List<Counter> counters)
        {
            var document = new XDocument(
                new XElement("Counters",
                    counters.Select(counter =>
                        new XElement("Counter",
                            new XElement("Name", counter.Name),
                            new XElement("StartCount", counter.StartCount)
                        )
                    )
                )
            );

            document.Save(FilePath);
        }

        public static List<Counter> LoadCounters()
        {
            if (!File.Exists(FilePath))
                return new List<Counter>();

            var document = XDocument.Load(FilePath);

            return document.Root?
                .Elements("Counter")
                .Select(element => new Counter
                {
                    Name = (string?)element.Element("Name") ?? "Counter",
                    StartCount = (int?)element.Element("StartCount") ?? 0
                })
                .ToList() ?? new List<Counter>();
        }

        public static void SaveStandardCounter(int count)
        {
            var document = File.Exists(FilePath)
                ? XDocument.Load(FilePath)
                : new XDocument(new XElement("Counters"));

            document.Root!.SetElementValue("StandardCounter", count);
            document.Save(FilePath);
        }

        public static int LoadStandardCounter()
        {
            if (!File.Exists(FilePath))
                return 0;

            var document = XDocument.Load(FilePath);

            return (int?)document.Root?.Element("StandardCounter") ?? 0;
        }
    }
}
