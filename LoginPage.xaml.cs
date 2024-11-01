using Firebase.Database;
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
            
        }

        // Firebase Link // 
        FirebaseClient firebaseClient = new FirebaseClient("https://nexcodb-default-rtdb.firebaseio.com/");

        // Retrieval and observing database //
        public ObservableCollection<Client> Client { get; set; } = new ObservableCollection<Client>();

       // Login Button // 
        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            bool found = false;
            Client.ToList().ForEach(item =>
            {
                if ((item.email == EmailText.Text))
                {
                    found = true;
                    if (item.password == PasswordText.Text)
                    {
                       
                        Navigation.PushAsync(new HomePage(item));                  
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

        // Test button // 
        private void Counter_Clicked(object sender, EventArgs e)
        {
            bool found = false;
            Client.ToList().ForEach(item =>
            {
                if ((item.email == EmailText.Text))
                {
                    found = true;
                    if (item.password == PasswordText.Text)
                    {
                        Navigation.PushAsync(new HomePage(item));
                    }
                }
               
            });
            // create new client with email and pass if it doesnt exist already (testing purposes) // 
            if (found == false) 
            {
                firebaseClient.Child("Client").PostAsync(new Client
                {
                    email = EmailText.Text,
                    password = PasswordText.Text,
                    userID = (Client.ToArray().Length+1),
                });
            }
        }
    }

}
