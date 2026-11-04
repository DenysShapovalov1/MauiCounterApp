using CounterProject.Models;
using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml;

namespace CounterProject.Views;

public partial class CountersPage : ContentPage
{
    int count = 0;

    Models.AllCounters allcounter = Models.AllCounters.Instance;

    public CountersPage()
	{
        InitializeComponent();

        count = CounterStorage.LoadStandardCounter();
        Counter_Text.Text = count.ToString();
        BindingContext = new Models.Counter();

        CountersCollection.ItemsSource = allcounter.counters;
        LoadCounters();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadCounters();
    }

    private void LoadCounters()
    {
        allcounter.counters.Clear();

        foreach (var counter in CounterStorage.LoadCounters())
        {
            allcounter.counters.Add(counter);
        }

    }

    private void Add_Click(object sender, EventArgs e)
    {
        count++;
        Counter_Text.Text = count.ToString();

        CounterStorage.SaveStandardCounter(count);
    }

    private void Sub_Click(object sender, EventArgs e)
    {
        count--;
        Counter_Text.Text = count.ToString();

        CounterStorage.SaveStandardCounter(count);
    }

    private void AddCounter_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button &&
            button.BindingContext is Models.Counter counter)
        {
            int index = allcounter.counters.IndexOf(counter);

            counter.StartCount++;

            allcounter.counters[index] = new Models.Counter
            {
                Name = counter.Name,
                StartCount = counter.StartCount
            };

            CounterStorage.SaveCounters(allcounter.counters.ToList());
        }
    }

    private void SubCounter_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button &&
            button.BindingContext is Models.Counter counter)
        {
            int index = allcounter.counters.IndexOf(counter);

            counter.StartCount--;

            allcounter.counters[index] = new Models.Counter
            {
                Name = counter.Name,
                StartCount = counter.StartCount
            };

            CounterStorage.SaveCounters(allcounter.counters.ToList());
        }
    }

    private async void GoTo_CreateCounterPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCounterPage));
    }
}
