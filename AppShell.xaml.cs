namespace NexcoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("homepage", typeof(HomePage));
            Routing.RegisterRoute("generateticket", typeof(GenerateTicket));
        }
    }
}
