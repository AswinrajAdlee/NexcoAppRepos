using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using static System.Net.Mime.MediaTypeNames;

namespace NexcoApp.Classes
{
    public class TicketsResolver
    {
        private List<string> preWrittenSolutions = new List<string> { 
            "Check the phone's physical connections, ensure the phone line is properly plugged in, and verify that the network is operational.",
            "Ensure the phone is properly registered with the network. Check the line connection and verify account status with the provider.",
            "Test with a different phone or cable. If the issue persists, check the network or contact the service provider for line clarity."};
        
        
        public Ticket? Ticketinfo;
        public string? solutionInfo;
        public DateTime? resolutionDate;
        public Agent? assignedAgent;
        public void DisplayTicketInformation()
        {

        }
        public void SetPriority()
        {

        } 

        public void UpdateTicketStatus()
        {

        }

        public string autoTicketSolver(int index, Agent workingAgent, Ticket selectedTicket)
        {
            return "Hi " + selectedTicket.clientInfo.fName + "!\r\n" +
            "\r\nThanks for reaching support!\r\n" + "My name is " + workingAgent.fName +
            " and I'll do my best to help you.\r\n\r\n" + preWrittenSolutions[index -1]
            + "\r\n\r\nBest regards,\r\n" + workingAgent.fName;
        }

    }
}
