namespace NexcoApp;
using NexcoApp.Classes;
using System.Net.Quic;

public partial class GenerateTicket : ContentPage
{
    private Client cClient;
	public GenerateTicket(Client client)
	{
		InitializeComponent();
        cClient = client;

	}

    private void ValueTest_Clicked(object sender, EventArgs e)
    {
        ValueTest.Text = cClient.userID.ToString();
    }
}