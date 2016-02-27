namespace MobileApp.Droid
{
    using System.Threading.Tasks;
    using Android.Webkit;
    using Microsoft.WindowsAzure.MobileServices;
    using Xamarin.Forms;

    class MobileClient : IMobileClient
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            return await App.Client.LoginAsync(Forms.Context, provider);
        }

        public async void Logout()
        {
            CookieManager.Instance.RemoveAllCookie();
            await App.Client.LogoutAsync();
        }
    }
}
