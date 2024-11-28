using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace NexcoApp.Classes
{
    public class Ticket
    {
        public string? title { get; set; }
        public int ticketID { get; set; } = 0;
        public DateTime issueStartDate { get; set; }
        public DateTime creationDate { get; set; }
        public string? issueDescription { get; set; }
        private bool isValid { get; set; }
        public Client? clientInfo { get; set; }
        public string? ticketStatus { get; set; } 
        public int ticketLevel { get; set; }
        public Color BackgroundColor { get; set; } = Colors.WhiteSmoke;
        public string? ticketSolution { get; set; }
        public Agent? agentAssigned { get; set; }
        public bool? clientSatisfied { get; set; } = false;
        public string? finalComments { get; set; }

        public string DisplayTicketID => $"Ticket ID: {ticketID}";


        private bool validateInfo()
        {
            return false;
        }

    }
}
