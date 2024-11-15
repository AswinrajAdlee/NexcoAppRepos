namespace NexcoApp;

using Firebase.Database;
using Firebase.Database.Query;
using NexcoApp.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;

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
        MyDatePicker.MaximumDate = DateTime.Today;

        var severityPicker = new List<string> {
            "Select Severity Level",
            "Minor (Small impact on functionalities)",
            "Major (Medium impact on fuctionaliies)",
            "Critical (High Impact on functionalities)"};
        sPicker.ItemsSource = severityPicker;
        sPicker.SelectedIndex = 0;
    }

    private async void SubmitBtn_Clicked(object sender, EventArgs e)
    {
        if (Title.Text == null || Description.Text == null || sPicker.SelectedIndex == 0)
        {
            await DisplayAlert("Error", "Please fill out required Information", "OK");
        }
        else
        {
            bool answer = await DisplayAlert("Verification", "Are all the information given true and correct?", "Submit", "Cancel");
            if (answer == true)
            {
                TicketsDB ticketsDB = new TicketsDB();
                ticketsDB.addTicket(
                    firebaseClient, 
                    "Open Ticket", 
                    Title.Text, 
                    Description.Text, 
                    cClient, 
                    MyDatePicker.Date, 
                    DateTime.Now,
                    "Open", 
                    sPicker.SelectedIndex);
                await DisplayAlert("Success", "Ticket has been successfully submitted!", "Close");
                Navigation.RemovePage(this);
            };
            
        }
    }
}
/*
await firebaseClient.Child("Open Ticket").PostAsync(new Ticket
                {
                    title = Title.Text,
                    issueDescription = Description.Text,
                    clientInfo = cClient,
                    issueStartDate = MyDatePicker.Date,
                    creationDate = DateTime.Now,
                    ticketID = await ticketsDB.retrieveNextID(firebaseClient),
                    ticketStatus = "Open",
                    ticketLevel = sPicker.SelectedIndex
                });*/