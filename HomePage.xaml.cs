using NexcoApp.Classes;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
namespace NexcoApp;

public partial class HomePage : ContentPage
{
    private Client cClient;
    FirebaseClient firebaseClient;
    ObservableCollection<Client> cClientlist;

    public HomePage(Client client, FirebaseClient firebase, ObservableCollection<Client> clientlist)
	{
		InitializeComponent();
        cClient = client;
        TicketsBtn.Text = cClient.password;
        firebaseClient = firebase;
        cClientlist = clientlist;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }

    private void TicketsBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GenerateTicket(cClient, firebaseClient, cClientlist));
    }
}