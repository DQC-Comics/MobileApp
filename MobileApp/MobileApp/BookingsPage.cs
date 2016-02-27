namespace MobileApp
{
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;

    public class BookingsPage : ContentPage
    {
        public BookingsPage(UserDetails user)
        {
            var contactList = new ListView
            {
                ItemsSource = new List<Booking>
                {
                    new Booking { HeroName = "Dave Bennet", Description = "ABC 123", StartTime = DateTime.Parse("2016-02-26 20:15"), EndTime = DateTime.Parse("2016-02-27 20:15") },
                    new Booking { HeroName = "Julie Rhodes", Description = "ABC 123", StartTime = DateTime.Parse("2016-02-26 20:15"), EndTime = DateTime.Parse("2016-02-27 20:15") },
                    new Booking { HeroName = "Jasmine Haskell", Description = "ABC 123", StartTime = DateTime.Parse("2016-02-26 20:15"), EndTime = DateTime.Parse("2016-02-27 20:15") }
                },
                RowHeight = 50,
                HasUnevenRows = true
            };
            contactList.ItemTemplate = new DataTemplate(typeof(TextCell));
            contactList.ItemTemplate.SetBinding(TextCell.TextProperty, "HeroName");

            contactList.ItemTapped += OnItemTapped;

            var newButton = new Button { Text = "Help me!" };
            newButton.Clicked += OnNewClicked;

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = 50,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label { Text = "Hello " + user.Name, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), FontAttributes = FontAttributes.Bold },
                    newButton,
                    contactList
                }
            };
        }

        private async void OnNewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewBookingPage());
        }

        private async void OnItemTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingDetailsPage((Booking)((ItemTappedEventArgs)e).Item));
        }
    }
}
