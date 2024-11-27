using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace NexcoApp.Classes
{
    public class Client : User
    {

        public string? companyName = "N/A";
        public string? companyStreet;
        public string? companyPostal;
        public bool isVerified;


        // GENERATE TICKETS PAGE //
        public void generateTicket(HomePage homepage, Client client, FirebaseClient firebase, ObservableCollection<Client> clientlist)
        {
            homepage.Navigation.PushAsync(new GenerateTicket(client, firebase, clientlist));
        }


        // SUBMIT THE TICKET - GOES TO TICKETSB (ADD TICKET) METHOD //
        private async void submitTicket(GenerateTicket ticketsPage, FirebaseClient firebaseClient, Ticket tTicket)
        {  
           TicketsDB ticketsDB = new TicketsDB();
            await ticketsDB.addTicket(
            firebaseClient,
            "Open Ticket",
            tTicket);
            await ticketsPage.DisplayAlert("Success", "Ticket has been successfully submitted!", "Close");
            ticketsPage.Navigation.RemovePage(ticketsPage);
          
        }
        public async void confirmSubmission(GenerateTicket ticketsPage, FirebaseClient firebaseClient, Ticket tTicket)
        {
            bool answer = await ticketsPage.DisplayAlert("Verification", "Are all the information given true and correct?", "Submit", "Cancel");
            if (answer == true)
            {
                submitTicket(ticketsPage, firebaseClient, tTicket);
            };
        }
    }
}
