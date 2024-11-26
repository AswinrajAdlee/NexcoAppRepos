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

        public async Task moveTicket(FirebaseClient firebaseClient, Ticket selectedTicket, Agent aAgent)
        {
            string key = "N/A";
            var collection = firebaseClient
               .Child("Open Ticket")
               .AsObservable<Ticket>()
               .Subscribe((item) =>
               {
                   if (item.Object.ticketID == selectedTicket.ticketID)
                   {
                       key = item.Key;
                   }
               });


            try
            {
       
                // Step 1: Read the ticket data from "Open Tickets"
                var openTicketData = await firebaseClient
                    .Child("Open Tickets")
                    .Child(key)
                    .OnceSingleAsync<Ticket>(); // Assuming Ticket is a model class


                // Step 2: Write the data to "Closed Tickets"
                addTicket(firebaseClient, "Pending Ticket", selectedTicket);

                // Step 3: Delete the data from "Open Tickets"
                await firebaseClient
                    .Child("Open Ticket")
                    .Child(key)
                    .DeleteAsync();

                Console.WriteLine("Ticket moved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving ticket: {ex.Message}");
            }
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
