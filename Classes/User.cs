using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexcoApp.Classes
{
    public class User
    {
        public int userID;
        public string? fName;
        public string? lName;
        public string? phone;
        public string? email;
        public int age;
        public DateTime birthDate;
        public string? password;
        public bool isLoggedIn;
        public string? companyInfo;

        public User(int userID, string? fName, string? lName, string? phone, string? email, int age, DateTime birthDate, string? password, bool isLoggedIn, string? companyInfo)
        {
            this.userID = userID;
            this.fName = fName;
            this.lName = lName;
            this.phone = phone;
            this.email = email;
            this.age = age;
            this.birthDate = birthDate;
            this.password = password;
            this.isLoggedIn = isLoggedIn;
            this.companyInfo = companyInfo;
        }

        public void Registration()
        {

        }

        public void Login()
        {

        }

        public void Logout()
        {

        }
    }
}
