using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoApp.Classes
    // child class of user //
{
    public class Admin : User
    {
        public Admin(int userID, string? fName, string? lName, string? phone, string? email, int age, DateTime birthDate, string? password, bool isLoggedIn, string? companyInfo) : base(userID, fName, lName, phone, email, age, birthDate, password, isLoggedIn, companyInfo)
        {
        }


        public void generateReport()
        {

        }
    }
}
