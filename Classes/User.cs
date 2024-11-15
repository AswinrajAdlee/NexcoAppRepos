using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace NexcoApp.Classes
{
    public class User()
    {
        public int userID; 
        public string fName = "N/A";
        public string lName = "N/A";
        public string phone = "N/A";
        public string email = "N/A";
        public int age;
        public DateTime birthDate; 
        public string password = "N/A";
        public bool isLoggedIn = false;
        public string key;
        
   
        public void Registration()
        {

        }

        public void Login(FirebaseClient firebaseClient)
        {
            firebaseClient.Child("Client").Child(key).PatchAsync(new { isLoggedIn = true });
            isLoggedIn = true;
        }

        public void Logout(FirebaseClient firebaseClient)
        {
            firebaseClient.Child("Client").Child(key).PatchAsync(isLoggedIn = false );
            isLoggedIn = false;
        }
    }
}
