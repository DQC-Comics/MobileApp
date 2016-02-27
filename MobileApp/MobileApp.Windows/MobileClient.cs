using System.Threading.Tasks;
using MobileApp.Windows;

[assembly: Xamarin.Forms.Dependency(typeof(MobileClient))]

namespace MobileApp.Windows
{
    using Microsoft.WindowsAzure.MobileServices;

    public class MobileClient : IMobileClient
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
        {
            return await MobileApp.App.Client.LoginAsync(provider);
        }

        public async void Logout()
        {
            await MobileApp.App.Client.LogoutAsync();
        }
    }
}
