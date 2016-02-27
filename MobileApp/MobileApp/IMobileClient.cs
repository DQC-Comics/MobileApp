namespace MobileApp
{
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.MobileServices;

    public interface IMobileClient
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider);
        void Logout();
    }
}
