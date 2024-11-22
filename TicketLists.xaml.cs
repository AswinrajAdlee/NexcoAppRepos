namespace NexcoApp;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using NexcoApp.Classes;


public partial class TicketLists : ContentPage
{
	FirebaseClient firebaseClient = new FirebaseClient("https://nexcodb-default-rtdb.firebaseio.com/");
    public ObservableCollection<Ticket> OpenTickets { get; set; } = new ObservableCollection<Ticket>();
    public TicketLists()
	{
		InitializeComponent();
        BindingContext = this;

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
                            issueDescription = item.Object.clientInfo.fName + " " + item.Object.clientInfo.lName,
                            creationDate = item.Object.creationDate,
                        };
                        OpenTickets.Add(newTicket);
                    }
                });

    }
}
