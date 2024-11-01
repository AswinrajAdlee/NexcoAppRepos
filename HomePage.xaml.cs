using NexcoApp.Classes;

namespace NexcoApp;

public partial class HomePage : ContentPage
{
    private Client cClient;
	public HomePage(Client client)
	{
		InitializeComponent();
        cClient = client;
        TicketsBtn.Text = cClient.password;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }

    private void TicketsBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GenerateTicket(cClient));
    }
}