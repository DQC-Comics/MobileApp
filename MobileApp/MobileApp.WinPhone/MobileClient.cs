﻿using MobileApp.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(MobileClient))]

namespace MobileApp.WinPhone
{
    using System.Threading.Tasks;
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
