

using NexcoApp.Classes;
using System.Runtime.CompilerServices;

namespace NexcoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        // When user clicks off, check if textbox is empty, if so, set it to "Email"//
        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailText.Text)) {
                EmailText.Text = "Email"; }
        }

        //When user clicks on textbox, if its "Email", set it empty //
        private void EmailText_Focused(object sender, FocusEventArgs e)
        {
            if (string.Equals(EmailText.Text, "Email"))
            {
                EmailText.Text = "";
            }
        }

        // Same unfocused as email, but for password textbox //
        private void PasswordText_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordText.Text))
            {
                PasswordText.Text = "Password";
                PasswordText.IsPassword = false;
            }
        }

        // same focus event for email, but for password instead //
        private void PasswordText_Focused(object sender, FocusEventArgs e)
        {
            if (string.Equals(PasswordText.Text, "Password"))
            {
                PasswordText.Text = "";
                PasswordText.IsPassword = true;
            }
        }

    
    }

}
