namespace MobileApp
{
    using Microsoft.WindowsAzure.MobileServices;
    using Xamarin.Forms;

    public class App : Application
    {
        public static MobileServiceClient Client { get; private set; }

        public static UserDetails User { get; set; }

        public App()
        {
            Client = new MobileServiceClient(@"https://dqccomics-mobileapi.azurewebsites.net");
            User = new UserDetails { Id = "mobile-test", Name = "Mobile Test User" };

            // The root page of your application
            MainPage = new NavigationPage(new LoginPage());
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
