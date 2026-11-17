
using System.Xml.Linq;

namespace CounterProject.Models
{
    public static class CounterStorage
    {
        private static readonly string FilePath =
            Path.Combine(FileSystem.AppDataDirectory, "counters.xml");

        public static void SaveCounters(List<Counter> counters)
        {
            XDocument document;

            if (File.Exists(FilePath))
            {
                document = XDocument.Load(FilePath);
            }
            else
            {
                document = new XDocument(new XElement("Counters"));
            }

            document.Root.Elements("Counter").Remove();

            foreach (Counter counter in counters)
            {
                XElement newCounter = new XElement("Counter");

                newCounter.Add(new XElement("Name", counter.Name));
                newCounter.Add(new XElement("StartCount", counter.StartCount));
                newCounter.Add(new XElement("CurrentCount", counter.CurrentCount));

                document.Root.Add(newCounter);
            }

            document.Save(FilePath);
        }

        public static List<Counter> LoadCounters()
        {
            List<Counter> counters = new List<Counter>();

            if (File.Exists(FilePath) == false)
            {
                return counters;
            }

            XDocument document = XDocument.Load(FilePath);

            foreach (XElement element in document.Root.Elements("Counter"))
            {
                Counter counter = new Counter();

                counter.Name = "Counter";

                if (element.Element("Name") != null)
                {
                    counter.Name = element.Element("Name").Value;
                }

                if (element.Element("StartCount") != null)
                {
                    counter.StartCount = int.Parse(element.Element("StartCount").Value);
                }

                counter.CurrentCount = counter.StartCount;

                if (element.Element("CurrentCount") != null)
                {
                    counter.CurrentCount = int.Parse(element.Element("CurrentCount").Value);
                }

                counters.Add(counter);
            }

            return counters;
        }

        public static void SaveStandardCounter(int count)
        {
            XDocument document;

            if (File.Exists(FilePath))
            {
                document = XDocument.Load(FilePath);
            }
            else
            {
                document = new XDocument(new XElement("Counters"));
            }

            document.Root.SetElementValue("StandardCounter", count);

            document.Save(FilePath);
        }

        public static int LoadStandardCounter()
        {
            if (File.Exists(FilePath) == false)
            {
                return 0;
            }

            XDocument document = XDocument.Load(FilePath);

            if (document.Root.Element("StandardCounter") != null)
            {
                return int.Parse(document.Root.Element("StandardCounter").Value);
            }

            return 0;
        }
    }
}
