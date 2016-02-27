namespace MobileApp
{
    using System;
    using Microsoft.WindowsAzure.MobileServices;
    using Xamarin.Forms;

    public class LoginPage : ContentPage
    {
        private Label messageLabel;

        public LoginPage()
        {
            var microsoftButton = new Button { Text = "Login with Microsoft Account", TextColor = Color.White, BackgroundColor = Color.FromHex("77D065") };
            microsoftButton.Clicked += OnMicrosoftAccountLoginClicked;

            var azureadButton = new Button { Text = "Login with Azure AD", TextColor = Color.White, BackgroundColor = Color.FromHex("77D065") };
            azureadButton.Clicked += OnAzureActiveDirectoryLoginClicked;

            messageLabel = new Label();

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = 50,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label { Text = "Welcome", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), FontAttributes = FontAttributes.Bold },
                    microsoftButton,
                    azureadButton,
                    messageLabel
                }
            };
        }

        private void OnMicrosoftAccountLoginClicked(object sender, EventArgs e)
        {
            LoginDone(MobileServiceAuthenticationProvider.MicrosoftAccount);
        }

        private void OnAzureActiveDirectoryLoginClicked(object sender, EventArgs e)
        {
            LoginDone(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
        }

        private async void LoginDone(MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var user = await DependencyService.Get<IMobileClient>().LoginAsync(provider);

                var me = await App.Client.InvokeApiAsync("/.auth/me");
                var userDetails = new UserDetails();
                userDetails.Id = me[0]["user_id"].ToString();
                foreach (var claim in me[0]["user_claims"])
                {
                    if (claim["typ"].ToString() == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                    {
                        userDetails.Name = claim["val"].ToString();
                    }
                }

                Navigation.InsertPageBefore(new BookingsPage(userDetails), this);
                await Navigation.PopAsync();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Authentication was cancelled"))
                {
                    messageLabel.Text = "Authentication cancelled by the user";
                }
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Authentication failed";
            }
        }
    }
}
