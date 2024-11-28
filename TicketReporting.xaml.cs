namespace NexcoApp;

using Firebase.Database;
using NexcoApp.Classes;

public partial class TicketReporting : ContentPage
{
    FirebaseClient firebaseClient;
    Ticket selectedtTicket;
    TicketLists ticketListPageref;
	public TicketReporting(string Title, TicketLists pageRef, Ticket selectedTicket, FirebaseClient firebaseClientref)
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

        if(Title == "Solved")
        {
            pageTitle.Text = "Solved Tickets";
            Satisfaction.IsChecked = selectedTicket.clientSatisfied.Value;
            Comments.Text = selectedTicket.finalComments;

            Satisfaction.IsEnabled = false;
            Comments.IsEnabled = false;
            Submit.Text = "Return";
        }
    }

    private async void SubmitBtn_Clicked(object sender, EventArgs e)
    {
        if(Submit.Text == "Return")
        {
            Navigation.RemovePage(this);
        }

        bool answer = await DisplayAlert("Verification", "Close ticket?", "Yes", "No");
        if(answer == true)
        {
            Submit.IsEnabled = false;
            Submit.Opacity = 0.8;
            TicketLogger ticketLogger = new TicketLogger();
            await ticketLogger.storeTicketInfo(firebaseClient, selectedtTicket, Satisfaction.IsChecked, Comments.Text);
            await DisplayAlert("Sucess!", "Ticket has been closed!", "Close");
            Navigation.RemovePage(ticketListPageref);
            Navigation.RemovePage(this);
        }
    }
}