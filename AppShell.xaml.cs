namespace NexcoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("homepage", typeof(HomePage));
            Routing.RegisterRoute("generateticket", typeof(GenerateTicket));
            Routing.RegisterRoute("registerpage", typeof(RegisterPage));
            Routing.RegisterRoute("homepageagent", typeof(HomePageAgent));
            Routing.RegisterRoute("verificationpage", typeof(VerificationPage));
            Routing.RegisterRoute("ticketfilterpage", typeof(TicketFilter));
            Routing.RegisterRoute("ticketlistpage", typeof(TicketLists));
            Routing.RegisterRoute("ticketresolvepage", typeof(TicketResolve));
        }
    }
}
