namespace CounterProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.AddCounterPage), typeof(Views.AddCounterPage));
            Routing.RegisterRoute(nameof(Views.CountersPage), typeof(Views.CountersPage));
        }
    }
}
