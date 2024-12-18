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
        NavigationPage.SetHasBackButton(this, false);
        cClient = client;
        firebaseClient = firebase;
        cClientlist = clientlist;
   

    // Set client key after login so that we can change database values later // 
    var collection = firebaseClient
               .Child("Client")
               .AsObservable<Client>()
               .Subscribe((item) =>
               {
                   if (item.Object.userID == cClient.userID)
                   {
                       cClient.key = item.Key;
                       cClient.Login(firebaseClient);
                   }
               });
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        cClient.Logout(firebaseClient);
        Navigation.RemovePage(this);
    }

    private void TicketsBtn_Clicked(object sender, EventArgs e)
    {
        // Generate Tickets Page //
        cClient.generateTicket(this, cClient, firebaseClient, cClientlist);
    }
}