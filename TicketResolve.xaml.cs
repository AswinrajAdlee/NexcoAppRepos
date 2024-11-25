namespace NexcoApp;
using NexcoApp.Classes;
using System.Reactive.Subjects;

public partial class TicketResolve : ContentPage
{
	public TicketResolve(Ticket selectedTicket)
	{
		InitializeComponent();
		Problem.Text = selectedTicket.issueDescription;
		userName.Text = selectedTicket.clientInfo.fName + " " + selectedTicket.clientInfo.lName;
		Address.Text = selectedTicket.clientInfo.companyStreet;
		userEmail.Text = selectedTicket.clientInfo.email;
		ticketSubject.Text = selectedTicket.title;
	
	}
}