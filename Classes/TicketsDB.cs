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




        public async void addTicket(FirebaseClient firebaseClient, string ttype, Ticket ticket)
        {
            await firebaseClient.Child(ttype).PostAsync(new Ticket
            {
                title = ticket.title,
                issueDescription = ticket.issueDescription,
                clientInfo = ticket.clientInfo,
                issueStartDate = ticket.issueStartDate,
                creationDate = ticket.creationDate,
                ticketID = await retrieveNextID(firebaseClient),
                ticketStatus = ticket.ticketStatus,
                ticketLevel = ticket.ticketLevel,
                BackgroundColor = ticket.BackgroundColor
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
