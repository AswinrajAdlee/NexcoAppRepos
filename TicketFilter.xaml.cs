namespace NexcoApp;

public partial class TicketFilter : ContentPage
{
	public TicketFilter()
	{
		InitializeComponent();
	}

    // Open Tickets Clicked // 
    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new TicketLists("Open Tickets"));
    }

    // Pending Tickets Clicked //
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TicketLists("Pending Tickets"));
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TicketLists("Solved Tickets"));
    }
}