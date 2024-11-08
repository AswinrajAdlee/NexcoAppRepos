namespace NexcoApp;
using Firebase.Database;
using Firebase.Database.Query;
public partial class RegisterPage : ContentPage
{
	FirebaseClient firebaseClient;
	public RegisterPage(FirebaseClient firebase)
	{
		InitializeComponent();
		firebaseClient = firebase;
	}
}