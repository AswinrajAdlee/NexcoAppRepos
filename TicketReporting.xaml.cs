namespace NexcoApp;

using Firebase.Database;
using NexcoApp.Classes;

public partial class TicketReporting : ContentPage
{
    FirebaseClient firebaseClient;
    Ticket selectedtTicket;
    TicketLists ticketListPageref;
	public TicketReporting(TicketLists pageRef, Ticket selectedTicket, FirebaseClient firebaseClientref)
	{
		InitializeComponent();

        Problem.Text = selectedTicket.issueDescription;
        userName.Text = selectedTicket.clientInfo.fName + " " + selectedTicket.clientInfo.lName;
        Address.Text = selectedTicket.clientInfo.companyStreet;
        userEmail.Text = selectedTicket.clientInfo.email;
        ticketSubject.Text = selectedTicket.title;
        Resolve.Text = selectedTicket.ticketSolution;
        agentName.Text = selectedTicket.agentAssigned.fName + " " + selectedTicket.agentAssigned.lName;
        agentCode.Text = selectedTicket.agentAssigned.agentCode;

        firebaseClient = firebaseClientref;
        selectedtTicket = selectedTicket;
        ticketListPageref = pageRef;
    }

    private async void SubmitBtn_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Verification", "Close ticket?", "Yes", "No");
        if(answer == true)
        {
            TicketLogger ticketLogger = new TicketLogger();
            await ticketLogger.storeTicketInfo(firebaseClient, selectedtTicket, Satisfaction.IsChecked, Comments.Text);
            Navigation.RemovePage(ticketListPageref);
            Navigation.RemovePage(this);
        }
    }
}