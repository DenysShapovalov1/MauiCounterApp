
using CounterProject.Models;

namespace CounterProject.Views;

public partial class AddCounterPage : ContentPage
{
    private readonly Models.AllCounters allcounter =
        Models.AllCounters.Instance;

    public AddCounterPage()
    {
        InitializeComponent();

        BindingContext = new Counter();
    }

    private async void Create_Counter(object sender, EventArgs e)
    {
        Counter counter = new Counter();

        counter.Name = TextEditor.Text;

        if (string.IsNullOrEmpty(counter.Name))
        {
            await DisplayAlert("Bład", "Pole z nazwą nie może być puste!", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(TextEditorNum.Text))
        {
            counter.StartCount = 0;
        }
        else if (int.TryParse(TextEditorNum.Text, out int number))
        {
            counter.StartCount = number;
        }
        else
        {
            await DisplayAlert("Bład", "Wprowadz liczbę", "OK");
            return;
        }

        allcounter.counters.Add(counter);

        CounterStorage.SaveCounters(
            allcounter.counters.ToList());

        await Shell.Current.GoToAsync("..");
    }
}
