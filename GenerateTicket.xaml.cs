namespace NexcoApp;
using Firebase.Database;
using Firebase.Database.Query;
using NexcoApp.Classes;
using System.Collections.ObjectModel;
using System.Net.Quic;

public partial class GenerateTicket : ContentPage
{
    private Client cClient;
    FirebaseClient firebaseClient;
    ObservableCollection<Client> cClientlist;
    private string key; 
    public GenerateTicket(Client client, FirebaseClient firebase, ObservableCollection<Client> clientlist)
    {
        InitializeComponent();
        cClient = client;
        firebaseClient = firebase;
        cClientlist = clientlist; 
    }

    private void ValueTest_Clicked(object sender, EventArgs e)
    {
        firebaseClient.Child("Client").Child(cClient.key).PatchAsync(new { email = "test" });
    }
}