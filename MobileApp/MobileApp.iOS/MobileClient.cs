namespace MobileApp.iOS
{
    using System.Threading.Tasks;
    using Foundation;
    using Microsoft.WindowsAzure.MobileServices;
    using UIKit;

    class MobileClient : IMobileClient
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            var view = UIApplication.SharedApplication.KeyWindow.RootViewController;
            return await App.Client.LoginAsync(view, provider);
        }

        public async void Logout()
        {
            foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
            {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }

            await MobileApp.App.Client.LogoutAsync();
        }
    }
}
