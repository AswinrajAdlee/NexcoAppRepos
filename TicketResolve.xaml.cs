namespace NexcoApp;

using Firebase.Database;
using Microsoft.Maui.Animations;
using NexcoApp.Classes;
using Org.BouncyCastle.Tls;
using System.Collections.Specialized;
using System.Reactive.Subjects;

public partial class TicketResolve : ContentPage
{
	private Agent aAgent;
	private Ticket tTicket;
	string messageBody;
	string defaultText;
	FirebaseClient firebaseClient;
	TicketLists ticketlistspage;
	public TicketResolve(TicketLists ticketListref, Ticket selectedTicket, Agent workingAgent, FirebaseClient firebaseClientref)
	{
		InitializeComponent();
		Problem.Text = selectedTicket.issueDescription;
		userName.Text = selectedTicket.clientInfo.fName + " " + selectedTicket.clientInfo.lName;
		Address.Text = selectedTicket.clientInfo.companyStreet;
		userEmail.Text = selectedTicket.clientInfo.email;
		ticketSubject.Text = selectedTicket.title;
		firebaseClient = firebaseClientref;
		ticketlistspage = ticketListref;
        aAgent = workingAgent;
        tTicket = selectedTicket;


        defaultText = "Hi " + selectedTicket.clientInfo.fName + "!\r\n" +
			"\r\nThanks for reaching support!\r\n" + "My name is " + workingAgent.fName +
			" and I'll do my best to help you.\r\n\r\n"
			+ "\r\n\r\nBest regards,\r\n" + workingAgent.fName;

		Resolve.Text = defaultText;
		messageBody = defaultText; 

		var commonResolvePicker = new List<string> {
			"Auto solution responses",
			"No Dial Tone",
			"Cannot Make or Receive Calls",
			"Static or Noise on the Line"};
		resolvePicker.ItemsSource = commonResolvePicker;
		resolvePicker.SelectedIndex = 0;
	}


	private async void SubmitBtn_Clicked(object sender, EventArgs e)
	{
		if (Resolve.Text != string.Empty)
		{
			bool answer = await DisplayAlert("Verification", "Confirm submit ticket?", "Submit", "Cancel");
			if (answer == true)
			{
				SubmitBtn.IsEnabled = false;
				SubmitBtn.Opacity = 0.8;
				EmailService emailService = new EmailService();
				await emailService.sendEmail(userEmail.Text, ticketSubject.Text + " #" + tTicket.ticketID, messageBody);
				TicketsDB ticketsDB = new TicketsDB();
				await ticketsDB.moveTicket(firebaseClient, tTicket, aAgent, Resolve.Text);
				await DisplayAlert("Sucess!", "Solution has been sent to Client", "Close");
				Navigation.RemovePage(ticketlistspage);
				Navigation.RemovePage(this);
			}
		}
	}

	public void resolvePicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (resolvePicker.SelectedIndex != 0)
		{
			var ticketsResolver = new TicketsResolver();
			messageBody = ticketsResolver.autoTicketSolver(resolvePicker.SelectedIndex, aAgent, tTicket);
			Resolve.Text = messageBody;
		}
		else
		{
			messageBody = defaultText;
			Resolve.Text = defaultText;
		}
	}
    private void Resolve_TextChanged(object sender, TextChangedEventArgs e)
    {
	
    }

}