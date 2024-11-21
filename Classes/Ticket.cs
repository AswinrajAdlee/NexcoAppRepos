using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoApp.Classes
{
    public class Ticket
    {
        public string title;
        public int ticketID;
        public DateTime issueStartDate;
        public DateTime creationDate;
        public string issueDescription;
        private bool isValid;
        public Client clientInfo;
        public string? ticketStatus;
        public int ticketLevel;


        private bool validateInfo()
        {
            return false;
        }

    }
}
