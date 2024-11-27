using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using NexcoApp.Classes;

namespace NexcoApp.Classes
{
    public class TicketLogger
    {
        public TicketsResolver solvedInfo;
        public void updateTicketDetails()
        {


        }
        
        public void saveTicket()
        {

        }

        public void getTicketDetails()
        {

        }

        public async Task storeTicketInfo(FirebaseClient firebaseClient, Ticket selectedTicket, bool satisfaction, string finalComment)
        {
            TicketsDB ticketsDB = new TicketsDB();
            string key = "N/A";
            var collection = firebaseClient
               .Child("Pending Ticket")
               .AsObservable<Ticket>()
               .Subscribe((item) =>
               {
                   if (item.Object.ticketID == selectedTicket.ticketID)
                   {
                       key = item.Key;
                       selectedTicket.clientSatisfied = satisfaction;
                       selectedTicket.finalComments = finalComment;
                       
                   }
               });

            try
            {

                // Step 1: Read the ticket data from "Open Tickets"
                var openTicketData = await firebaseClient
                    .Child("Pending Ticket")
                    .Child(key)
                    .OnceSingleAsync<Ticket>(); // Assuming Ticket is a model class


                // Step 2: Write the data to "Closed Tickets"
                await ticketsDB.addTicket(firebaseClient, "Solved Ticket", selectedTicket);

                // Step 3: Delete the data from "Open Tickets"
                await ticketsDB.removeTicket(firebaseClient, "Pending Ticket", key);

                Console.WriteLine("Ticket moved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving ticket: {ex.Message}");
            }


        }

    }
}
