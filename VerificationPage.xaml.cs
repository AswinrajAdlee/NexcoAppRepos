using Firebase.Database;
using NexcoApp.Classes;
namespace NexcoApp;

public partial class VerificationPage : ContentPage
{
    RegisterPage rpageRef;
    string vToken;
	public VerificationPage(string userEmail, string verificationToken, RegisterPage registerPageRef)
	{
		InitializeComponent();
        rpageRef = registerPageRef;
        vToken = verificationToken;
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	{ 
		if(FirstEntry.Text != string.Empty)
		{
			SecondEntry.Focus();
		}

    }

    private void SecondEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (SecondEntry.Text != string.Empty)
        {
            ThirdEntry.Focus();
        }
    }

    private void ThirdEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (ThirdEntry.Text != string.Empty)
        {
            FourthEntry.Focus();
        }
    }

    private void FourthEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (FourthEntry.Text != string.Empty)
        {
            FifthEntry.Focus();
        }
    }

    private void FifthEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (FifthEntry.Text != string.Empty)
        {
            SixthEntry.Focus();
        }
    }

    private async void SixthEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string Code;
        Code = (FirstEntry.Text + SecondEntry.Text + ThirdEntry.Text + FourthEntry.Text + FifthEntry.Text + SixthEntry.Text);
        if (Code == vToken)
        {
            TheBox.TranslateTo(0, 50, 200, Easing.CubicInOut);
            emailImage.IsVisible = true;
            emailImage.FadeTo(1, 1000, Easing.CubicInOut);
            VerificationText.Text = "Email has been verified!";
            Client client = new Client();

            client.fName = rpageRef.fFname;
            client.lName = rpageRef.lLname;
            client.companyName = rpageRef.cCompanyName;
            client.companyStreet = rpageRef.companyAddress;
            client.companyPostal = rpageRef.companyPostal;
            client.email = rpageRef.userEmail;
            client.password = rpageRef.userPass;
            client.userID = rpageRef.ID;
            client.Registration(client);
            await Task.Delay(1000);
            Navigation.RemovePage(rpageRef);
            await Task.Delay(100);
            Navigation.RemovePage(this);

        }
    }
}