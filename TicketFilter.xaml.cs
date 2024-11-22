namespace NexcoApp;

public partial class TicketFilter : ContentPage
{
	public TicketFilter()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new TicketLists());
    }
}