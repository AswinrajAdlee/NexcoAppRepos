using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;


namespace NexcoApp.Classes
{
    public class TicketsDB
    {
        public ObservableCollection<Ticket>? openTickets { get; set; } = new ObservableCollection<Ticket>();
        public ObservableCollection<Ticket>? closedTickets { get; set; } = new ObservableCollection<Ticket>();




        public async void addTicket(FirebaseClient firebaseClient, string ttype, string tTitle, string tDescription, Client cClient, DateTime tstartDate, DateTime tcreationDate,string tticketStatus, int tticketLevel)
        {
            await firebaseClient.Child(ttype).PostAsync(new Ticket
            {
                title = tTitle,
                issueDescription = tDescription,
                clientInfo = cClient,
                issueStartDate = tstartDate,
                creationDate = tcreationDate,
                ticketID = await retrieveNextID(firebaseClient),
                ticketStatus = tticketStatus,
                ticketLevel = tticketLevel
            });

        }

        public void removeTicket()
        {

        }

        public void updateTicketInfo()
        {

        }

        public void retrieveInfo()
        {
            

        }

        public async Task<int> retrieveNextID(FirebaseClient firebaseClient)
        {
            var opencollection = await firebaseClient
               .Child("Open Ticket")
               .OnceAsync<Ticket>();
            var closedcollection = await firebaseClient
                .Child("Closed Ticket")
                .OnceAsync<Ticket>();
            return opencollection.Count + closedcollection.Count + 1; 

        }
    }

}
