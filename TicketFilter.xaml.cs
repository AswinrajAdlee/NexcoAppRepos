using NexcoApp.Classes;

namespace NexcoApp;

public partial class TicketFilter : ContentPage
{
    private Agent aAgent;
	public TicketFilter(Agent workingAgent)
	{
		InitializeComponent();
        aAgent = workingAgent;
	}

    // Open Tickets Clicked // 
    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new TicketLists("Open Tickets", aAgent));
    }

    // Pending Tickets Clicked //
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TicketLists("Pending Tickets", aAgent));
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TicketLists("Solved Tickets", aAgent));
    }
}