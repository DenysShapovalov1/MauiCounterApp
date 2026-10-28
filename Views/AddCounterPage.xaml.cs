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
    }

    private async void Create_Counter(object sender, EventArgs e)
    {
		Models.Counter counter = new Models.Counter();

        counter.Name = TextEditor.Text;
		if (string.IsNullOrEmpty(TextEditorNum.Text))
			counter.StartCount = 0;
        else int.TryParse(TextEditorNum.Text, out counter.StartCount);

        allcounter.counters.Add(counter);

        CounterStorage.SaveCounters(allcounter.counters);

        await Shell.Current.GoToAsync("..");
		
    }
}