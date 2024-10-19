using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NexcoApp.Classes
{
    public class Client : User
    {

        public string? associatedCompany;
        public string? companyID;


        public Client(int userID, string? fName, string? lName, string? phone, string? email, int age, DateTime birthDate, string? password, bool isLoggedIn, string? companyInfo) : base(userID, fName, lName, phone, email, age, birthDate, password, isLoggedIn, companyInfo)
        { 
          
        }

        public void generateTicket()
        {

        }
        private bool confirmSubmission()
        {
            return false;
        }
    }
}
