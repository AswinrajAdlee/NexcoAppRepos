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
        ValueTest.Text = cClient.userID.ToString();

        cClientlist.ToList().ForEach(item =>
        {
        if ((item.userID == cClient.userID))
        {
            if (item.email == "test@gmail.com")
            {
                key = item.ToString();
                item.email = "test";
                firebaseClient.Child("Client").Child(key).PostAsync(new Client { email = "test" });
                ValueTest.Text = item.ToString();
            }
                else
                {
 
                }
            }

        });
    }
}