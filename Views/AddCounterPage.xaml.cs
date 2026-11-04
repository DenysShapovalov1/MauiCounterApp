using CounterProject.Models;
using System.Diagnostics;
using System.Threading.Tasks;
namespace CounterProject.Views;

public partial class AddCounterPage : ContentPage
{
    Models.AllCounters allcounter = Models.AllCounters.Instance;
    public AddCounterPage()
	{
		InitializeComponent();

        BindingContext = new Models.Counter();
    }

    private async void Create_Counter(object sender, EventArgs e)
    {
		Models.Counter counter = new Models.Counter();

        counter.Name = TextEditor.Text;
        if (string.IsNullOrEmpty(TextEditorNum.Text))
        {
            counter.StartCount = 0;
        }
        else
        {
            if (int.TryParse(TextEditorNum.Text, out int number))
            {
                counter.StartCount = number;
            }
            else
            {
                await DisplayAlert("Blad", "Wprowadz liczbe", "OK");
                return;
            }
        }

         allcounter.counters.Add(counter);

        CounterStorage.SaveCounters(allcounter.counters.ToList());

        await Shell.Current.GoToAsync("..");
		
    }
}
