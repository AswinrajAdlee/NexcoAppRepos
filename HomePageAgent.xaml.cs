using NexcoApp.Classes;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
namespace NexcoApp;

public partial class HomePageAgent : ContentPage
{
    private Agent aAgent;
    FirebaseClient firebaseClient;
    ObservableCollection<Agent> aAgentList;

    public HomePageAgent(Agent agent, FirebaseClient firebase, ObservableCollection<Agent> agentlist)
	{
        InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);
        aAgent = agent;
        firebaseClient = firebase;
        aAgentList = agentlist;
        WelcomeMsg.Text = "Welcome " + agent.fName;


        // Set client key after login so that we can change database values later // 
        var collection = firebaseClient
               .Child("Agent")
               .AsObservable<Agent>()
               .Subscribe((item) =>
               {
                   if (item.Object.userID == aAgent.userID)
                   {
                       aAgent.key = item.Key;
                       aAgent.Login(firebaseClient);
                   }
               });
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        aAgent.Logout(firebaseClient);
        Navigation.RemovePage(this);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TicketFilter(aAgent));
    }
}