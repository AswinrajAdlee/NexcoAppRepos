namespace NexcoApp;
using Firebase.Database;
using Firebase.Database.Query;
using MailKit;
using Microsoft.Maui.ApplicationModel.Communication;
using NexcoApp.Classes;
using Org.BouncyCastle.Bcpg;
using System.Collections.ObjectModel;
using System.Reflection;

public partial class RegisterPage : ContentPage
{
    private Agent? aAgent;
	FirebaseClient firebaseClient;
    ObservableCollection<Agent> ?Agentlist;
    ObservableCollection<Client>? Clientlist;
    bool clientFound = false;
    public string fFname, lLname, cCompanyName,companyAddress, companyPostal, userEmail, userPass;
    public int ID;

    public RegisterPage(FirebaseClient firebase, ObservableCollection<Agent> agentlist, ObservableCollection<Client>? clientList)
	{
		InitializeComponent();
		firebaseClient = firebase;
        Agentlist = agentlist;
        Clientlist = clientList;


    }

    private async void RegisterBtn_Clicked(object sender, EventArgs e)
    {
        // Check to see if everything is filled out //
        if (fNameText.Text == null || lNameText.Text == null || EmailText.Text == null || ConfirmPasswordText.TextColor != Colors.LightGreen || CompanyName.Text == null || CompanyAddressStreet == null || CompanyAddressPostal.Text.Length < 6)
        {
            await DisplayAlert("Error", "Make sure to fill out all required information", "Accept");
            return;
        }
        // Check if "Register as Agent" is checked // 
        else if (AgentCheckBox.IsChecked == true)
        {
            bool agentFound = false;
            Agentlist.ToList().ForEach(async itemAgent =>
            {
                // Check if agent code matches any agent code in db and if they are already registered or not //
                if ((itemAgent.agentCode == AgentCode.Text && itemAgent.isRegistered == false))
                {
                    agentFound = true;
                    var collectionAgent = firebaseClient
                    .Child("Agent")
                    .AsObservable<Agent>()
                    .Subscribe((itemAgent2) =>
                     {
                         if (itemAgent2.Object.agentCode == AgentCode.Text)
                         {
                             // Update db once found and not registered //
                             firebaseClient.Child("Agent").Child(itemAgent2.Key).PatchAsync(new
                             {
                                 fname = fNameText.Text,
                                 lname = lNameText.Text,
                                 companyName = CompanyName.Text,
                                 companyAddressStreet = CompanyAddressStreet.Text,
                                 CompanyAddressPostal = CompanyAddressPostal.Text,
                                 email = EmailText.Text,
                                 password = PasswordText.Text,
                                 userID = (Clientlist.ToArray().Length + Agentlist.ToArray().Length + 1),
                                 isRegistered = true,
                             });
                             return;
                         }
                     });
                }
            });
            // Agent code not found in db //
            if (agentFound == false)
            {
                await DisplayAlert("Error", "No Agent with that agent code was found", "Accept");
            }
        }
        else
        {
            // Look to see if email is already registered for client //
            Clientlist.ToList().ForEach(async item =>
            {
                if (item.email == EmailText.Text)
                {
                    clientFound = true;
                    await DisplayAlert("Error", "Email is alraedy registered to an account", "Accept");
                }
            });
        }
        if (clientFound == false && AgentCheckBox.IsChecked == false)
        {

            EmailService emailService = new EmailService();
            string token = emailService.generateEmailVerificationToken();
            await emailService.sendEmail(this, EmailText.Text, token);
            fFname = fNameText.Text;
            lLname = lNameText.Text;
            cCompanyName = CompanyName.Text;
            companyAddress = CompanyAddressStreet.Text;
            companyPostal = CompanyAddressPostal.Text;
            userEmail = EmailText.Text;
            userPass = PasswordText.Text;
            ID = (Clientlist.ToArray().Length + Agentlist.ToArray().Length + 1);

        }
    }

    private void ReturnLoginButton_Clicked(object sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }

    private void PasswordText_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (PasswordText.Text.Length >= 8)
        {
            PasswordText.TextColor = Colors.LightGreen;
        }
        else
        {
            PasswordText.TextColor = Color.FromArgb("#f13006");
        }
    }

    private void ConfirmPasswordText_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (ConfirmPasswordText.Text == PasswordText.Text && PasswordText.TextColor == Colors.LightGreen)
        {
            ConfirmPasswordText.TextColor = Colors.LightGreen;
        }
        else
        {
            ConfirmPasswordText.TextColor = Color.FromArgb("#f13006");
        }
    }

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (AgentCheckBox.IsChecked) 
        {
            AgentBox.IsVisible = true;
            await Task.Delay(100);
            await MyScrollView.ScrollToAsync(0, double.MaxValue, true);
        }
        else
        {
            AgentBox.IsVisible = false;
        }
    }
}