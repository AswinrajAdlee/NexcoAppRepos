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




        public async Task addTicket(FirebaseClient firebaseClient, string ttype, Ticket ticket)
        {
            await firebaseClient.Child(ttype).PostAsync(new Ticket
            {
                title = ticket.title,
                issueDescription = ticket.issueDescription,
                clientInfo = ticket.clientInfo,
                issueStartDate = ticket.issueStartDate,
                creationDate = ticket.creationDate,
                ticketID = await retrieveNextID(firebaseClient, ticket.ticketID),
                ticketStatus = ticket.ticketStatus,
                ticketLevel = ticket.ticketLevel,
                BackgroundColor = ticket.BackgroundColor,
                ticketSolution = ticket.ticketSolution,
                agentAssigned = ticket.agentAssigned,
                clientSatisfied = ticket.clientSatisfied,
                finalComments = ticket.finalComments
            });


        }

        public async Task removeTicket(FirebaseClient firebaseClient, string ticketType, string key)
        {
              await firebaseClient
                    .Child(ticketType)
                    .Child(key)
                    .DeleteAsync();
        }

        public async Task moveTicket(FirebaseClient firebaseClient, Ticket selectedTicket, Agent aAgent, string solutionText)
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
                       selectedTicket.ticketSolution = solutionText;
                       selectedTicket.agentAssigned = aAgent;
                   }
               });
            await Task.Delay(500);
            try
            {
       
                // Step 1: Read the ticket data from "Open Tickets"
                var openTicketData = await firebaseClient
                    .Child("Open Tickets")
                    .Child(key)
                    .OnceSingleAsync<Ticket>(); // Assuming Ticket is a model class


                // Step 2: Write the data to "Closed Tickets"
                await addTicket(firebaseClient, "Pending Ticket", selectedTicket);

                // Step 3: Delete the data from "Open Tickets"
                await removeTicket(firebaseClient, "Open Ticket" ,key);

           
            }
            catch (Exception ex)
            {
             
            }
        }



        public void retrieveInfo()
        {
            

        }



        public async Task<int> retrieveNextID(FirebaseClient firebaseClient, int ticketID)
        {
            if (ticketID == 0)
            {
                var opencollection = await firebaseClient
                   .Child("Open Ticket")
                   .OnceAsync<Ticket>();
                var pendingcollection = await firebaseClient
                    .Child("Pending Ticket")
                    .OnceAsync<Ticket>();
                var solvedcollection = await firebaseClient
                    .Child("Solved Ticket")
                    .OnceAsync<Ticket>();
                return opencollection.Count + pendingcollection.Count + solvedcollection.Count + 1;
            }
            else
            {
                return ticketID;
            }
        }
    }

}
