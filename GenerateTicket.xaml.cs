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
    Ticket newTicket = new Ticket();
    Color ticketColor;
    public GenerateTicket(Client client, FirebaseClient firebase, ObservableCollection<Client> clientlist)
    {
        InitializeComponent();
        cClient = client;
        firebaseClient = firebase;
        cClientlist = clientlist;
        MyDatePicker.MaximumDate = DateTime.Today;

        // Set severity picker drop menu visuals //
        var severityPicker = new List<string> {
            "Select Severity Level",
            "Minor (Small impact on functionalities)",
            "Major (Medium impact on fuctionaliies)",
            "Critical (High Impact on functionalities)"};
        sPicker.ItemsSource = severityPicker;
        sPicker.SelectedIndex = 0;
    }

    // Submit clicked //
    private async void SubmitBtn_Clicked(object sender, EventArgs e)
    {
        if (Title.Text == null || Description.Text == null || sPicker.SelectedIndex == 0)
        {
            await DisplayAlert("Error", "Please fill out required Information", "OK");
        }
        else
        {
            setTicketInfo();
            cClient.confirmSubmission(this, firebaseClient, newTicket);
        }
    }
    // Set ticket info //
    private void setTicketInfo()
    {
        newTicket.title = Title.Text;
        newTicket.issueDescription = Description.Text;
        newTicket.issueStartDate = DateTime.Today;
        newTicket.ticketLevel = sPicker.SelectedIndex;
        newTicket.ticketStatus = "Open";
        newTicket.clientInfo = cClient;
        newTicket.creationDate = DateTime.Now;
        newTicket.BackgroundColor = ticketColor;
    }
    // Cancel clicked //
    private async void CancelBtn_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Alert", "Are you sure you want to cancel? All information will be deleted", "Confirm", "Return");
        if (answer == true)
        {
            Navigation.RemovePage(this);
        }
    }


    private void sPicker_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        if (sPicker.SelectedIndex == 1)
        {
            ticketColor = Colors.WhiteSmoke;
        }
        if (sPicker.SelectedIndex == 2)
        {
            ticketColor = Color.FromArgb("#FF7F50");
        }
        if (sPicker.SelectedIndex == 3)
        {
            ticketColor = Color.FromArgb("#FF7276");
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