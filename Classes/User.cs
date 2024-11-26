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
        public string key = "N/A";
        
   
        public async void Registration(Client cClient)
        {
            FirebaseClient firebaseClient = new FirebaseClient("https://nexcodb-default-rtdb.firebaseio.com/");
            await firebaseClient.Child("Client").PostAsync(new Client
            {
                fName = cClient.fName,
                lName = cClient.lName,
                companyName = cClient.companyName,
                companyStreet = cClient.companyStreet,
                companyPostal = cClient.companyPostal,
                email = cClient.email,
                password = cClient.password,
                userID = cClient.userID,
                isVerified = true,
                
            });
        }

        public void Login(FirebaseClient firebaseClient)
        {
            firebaseClient.Child("Client").Child(key).PatchAsync( isLoggedIn = true );
            isLoggedIn = true;
        }

        public void Logout(FirebaseClient firebaseClient)
        {
            firebaseClient.Child("Client").Child(key).PatchAsync(isLoggedIn = false );
            isLoggedIn = false;
        }
    }
}
