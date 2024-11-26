namespace NexcoApp; 
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using NexcoApp.Classes;


public partial class TicketLists : ContentPage
{
	FirebaseClient firebaseClient = new FirebaseClient("https://nexcodb-default-rtdb.firebaseio.com/");
    public ObservableCollection<Ticket> OpenTickets { get; set; } = new ObservableCollection<Ticket>();
    private Agent aAgent;
    public TicketLists(string pageTitle, Agent workingAgent)
	{
		InitializeComponent();
        BindingContext = this;
        Title.Text = pageTitle;
        aAgent = workingAgent;

        // If open tickets, then get open tickets from db //
        if (pageTitle == "Open Tickets")
        {
            var collectionAgent = firebaseClient
                    .Child("Open Ticket")
                    .AsObservable<Ticket>()
                    .Subscribe((item) =>
                    {
                        if (item.Object != null)
                        {
                            var newTicket = new Ticket
                            {
                                title = item.Object.title,
                                issueDescription = item.Object.issueDescription,
                                creationDate = item.Object.creationDate,
                                ticketLevel = item.Object.ticketLevel,
                                BackgroundColor = item.Object.BackgroundColor,
                                clientInfo = item.Object.clientInfo,
                                ticketID = item.Object.ticketID
                            };
                            OpenTickets.Add(newTicket);
                        }
                    });
        }
        if (pageTitle == "Pending Tickets")
        {
            var collectionAgent = firebaseClient
                    .Child("Pending Ticket")
                    .AsObservable<Ticket>()
                    .Subscribe((item) =>
                    {
                        if (item.Object != null)
                        {
                            var newTicket = new Ticket
                            {
                                title = item.Object.title,
                                issueDescription = item.Object.issueDescription,
                                creationDate = item.Object.creationDate,
                                ticketLevel = item.Object.ticketLevel,
                                BackgroundColor = item.Object.BackgroundColor,
                                clientInfo = item.Object.clientInfo,
                                ticketID = item.Object.ticketID
                            };
                            OpenTickets.Add(newTicket);
                        }
                    });
        }
    }

    // Open Tickets Resolver //
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var frame = sender as Frame;

        if (frame.BindingContext is Ticket tappedTicket)
        {
            await Navigation.PushAsync(new TicketResolve(this, tappedTicket, aAgent, firebaseClient));
        }
    }
}
