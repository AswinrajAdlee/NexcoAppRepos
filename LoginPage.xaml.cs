

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

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
           Shell.Current.GoToAsync("homepage");
        }
    }

}
