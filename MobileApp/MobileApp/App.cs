namespace MobileApp
{
    using Microsoft.WindowsAzure.MobileServices;
    using Xamarin.Forms;

    public class App : Application
    {
        public static MobileServiceClient Client { get; private set; }

        public App()
        {
            Client = new MobileServiceClient(@"https://dqccomics-mobileapi.azurewebsites.net");

            // The root page of your application
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new BookingsPage(new UserDetails { Name = "Demo User" }));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
