using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexcoApp.Classes;

namespace NexcoApp.Classes
{
    internal class EmailService
    {
        private string email;
        public void sendEmail(string userEmail)
        {
            email = userEmail;
        }

        public void verifyEmail (string userEmail)
        {

        }
        

    }
}
