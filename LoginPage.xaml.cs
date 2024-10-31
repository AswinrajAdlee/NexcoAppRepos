

using Firebase.Database;
using Firebase.Database.Query;
using NexcoApp.Classes;
using System.Collections.ObjectModel;

namespace NexcoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            //Firebase Retrieval of test database//
            var collection = firebaseClient
                .Child("Random Entry")
                .AsObservable<Database>()
                .Subscribe((item) =>
                {
                    if (item.Object != null)
                    {
                        Database.Add(item.Object);
                    }
                });
        }


        // Firebase Link // 
        FirebaseClient firebaseClient = new FirebaseClient("https://nexcodb-default-rtdb.firebaseio.com/");

        // Retrieval and observing database //
        public ObservableCollection<Database> Database { get; set; } = new ObservableCollection<Database>();

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
           Shell.Current.GoToAsync("homepage");
        }

        // Test button // 
        private void Counter_Clicked(object sender, EventArgs e)
        {
            firebaseClient.Child("Random Entry").PostAsync(new Database
            {
                Title = TitleEntry.Text,
            });
        }

        private void CheckTest_Clicked(object sender, EventArgs e)
        {
            Database.ToList().ForEach(item =>
            {
                if ((item.Title == EmailText.Text))
                {
                    Shell.Current.GoToAsync("homepage");
                }
                else
                {
                  
                }
            });
        }
    }

}
