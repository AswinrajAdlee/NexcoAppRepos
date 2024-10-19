using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoApp.Classes
{
    public class Ticket
    {
        public required string title;
        public int ticketID;
        public DateTime creationDate;
        public required string issueDescription;
        private bool isValid;
        public required Client clientInfo;
        public string? ticketStatus;
        public int ticketLevel;


        private bool validateInfo()
        {
            return false;
        }
    }
}
