﻿using Firebase.Database;
using Firebase.Database.Query;
using NexcoApp.Classes;
using System.Collections.ObjectModel;
using System.Linq;

namespace NexcoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Firebase Retrieval of client info from database //
            var collection = firebaseClient
                .Child("Client")
                .AsObservable<Client>()
                .Subscribe((item) =>
                {
                    if (item.Object != null)
                    {
                        Client.Add(item.Object);
                    }
                });
            // Retrieve Agents // 
            var collectionAgent = firebaseClient
                .Child("Agent")
                .AsObservable<Agent>()
                .Subscribe((itemAgent) =>
                {
                    if (itemAgent.Object != null)
                    {
                        Agent.Add(itemAgent.Object);
                    }
                });
            
        }

        // Firebase Link // 
        FirebaseClient firebaseClient = new FirebaseClient("https://nexcodb-default-rtdb.firebaseio.com/");

        // Retrieval and observing Client/Agent database //
        public ObservableCollection<Client> Client { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Agent> Agent { get; set; } = new ObservableCollection<Agent>();

        // Login Button // 
        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            bool found = false;
            // Look for if its a client
            Client.ToList().ForEach(item =>
            {
                if ((item.email == EmailText.Text))
                {
                    found = true;
                    byte[] retrievedSalt = Convert.FromBase64String(item.userSalt);
                    bool isPasswordCorrect = Login_and_Registration_Checker.validateUserCredentials(PasswordText.Text, item.password, retrievedSalt);
                    if (isPasswordCorrect == true)
                    {
                        Navigation.PushAsync(new HomePage(item, firebaseClient, Client));
                    }
                    else
                    {
                        found = false;
                    }
                }
            });
            // Look for if its an agent 
            Agent.ToList().ForEach(itemAgent =>
            {
                if ((itemAgent.email == EmailText.Text))
                {
                    found = true;
                    byte[] retrievedSalt = Convert.FromBase64String(itemAgent.userSalt);
                    bool isPasswordCorrect = Login_and_Registration_Checker.validateUserCredentials(PasswordText.Text, itemAgent.password, retrievedSalt);
                    if (isPasswordCorrect == true)
                    {
                       Navigation.PushAsync(new HomePageAgent(itemAgent, firebaseClient, Agent));
                    }
                    else
                    {
                        found = false;
                    }
                }
            });
            
            if (found == false)
            {
                // show a box saying that the email or password is incorrect // 
                DisplayAlert("Error", "Email or Password is Incorrect", "OK");
            }

            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            // Navigate to Register Page (Passing through firebase database) //
            Navigation.PushAsync(new RegisterPage(firebaseClient, Agent, Client));
        }
    }

}
