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

        allcounter.counters.Clear();

        foreach (var counter in CounterStorage.LoadCounters())
        {
            allcounter.counters.Add(counter);
        }

        CheckCounters();


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        CheckCounters();
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

    private void AddCounter(Models.Counter counter, Label label)
    {
        counter.StartCount++;
        label.Text = $"{counter.Name}: {counter.StartCount}";

    }

    private void SubCounter(Models.Counter counter, Label label)
    {
        counter.StartCount--;
        label.Text = $"{counter.Name}: {counter.StartCount}";

    }

    private void CheckCounters()
    {
        DynamicCountersLayout.Children.Clear();

        foreach (var counter in allcounter.counters)
        {
            var nameLabel = new Label
            {
                Text = counter.Name,
                FontSize = 16,
                TextColor = Colors.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var countLabel = new Label
            {
                Text = counter.StartCount.ToString(),
                FontSize = 20,
                TextColor = Colors.White,
                WidthRequest = 40,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center
            };

            var minusButton = new Button
            {
                Text = "-",
                WidthRequest = 44,
                HeightRequest = 44,
                Padding = 0,
                CornerRadius = 10
            };

            minusButton.Clicked += (sender, e) =>
            {
                counter.StartCount--;
                countLabel.Text = counter.StartCount.ToString();
                CounterStorage.SaveCounters(allcounter.counters);
            };

            var plusButton = new Button
            {
                Text = "+",
                WidthRequest = 44,
                HeightRequest = 44,
                Padding = 0,
                CornerRadius = 10
            };

            plusButton.Clicked += (sender, e) =>
            {
                counter.StartCount++;
                countLabel.Text = counter.StartCount.ToString();
                CounterStorage.SaveCounters(allcounter.counters);
            };

            var counterRow = new HorizontalStackLayout
            {
                Spacing = 12,
                VerticalOptions = LayoutOptions.Center
            };

            counterRow.Children.Add(nameLabel);
            counterRow.Children.Add(minusButton);
            counterRow.Children.Add(countLabel);
            counterRow.Children.Add(plusButton);

            var counterBorder = new Border
            {
                Padding = 12,
                Stroke = Colors.Gray,
                StrokeThickness = 1,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = 12
                },
                Content = counterRow
            };

            DynamicCountersLayout.Children.Add(counterBorder);
        }
    }

    private async void GoTo_CreateCounterPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCounterPage));
    }
}