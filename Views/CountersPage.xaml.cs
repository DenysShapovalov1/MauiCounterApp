
using CounterProject.Models;

namespace CounterProject.Views;

public partial class CountersPage : ContentPage
{
    private int count;

    private readonly Models.AllCounters allcounter =
        Models.AllCounters.Instance;

    public CountersPage()
    {
        InitializeComponent();

        count = CounterStorage.LoadStandardCounter();
        Counter_Text.Text = count.ToString();

        BindingContext = new Counter();

        CountersCollection.ItemsSource = allcounter.counters;

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
        Button button = (Button)sender;
        Counter counter = (Counter)button.BindingContext;

        counter.CurrentCount++;

        CounterStorage.SaveCounters(allcounter.counters.ToList());
    }

    private void SubCounter_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Counter counter = (Counter)button.BindingContext;

        counter.CurrentCount--;

        CounterStorage.SaveCounters(allcounter.counters.ToList());
    }

    private async void GoTo_CreateCounterPage(
        object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCounterPage));
    }
}
