namespace MobileApp
{
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;

    public class BookingsPage : ContentPage
    {
        private Label messageLabel;
        private ListView contactList;

        public BookingsPage()
        {
            messageLabel = new Label();

            contactList = new ListView
            {
                RowHeight = 50,
                HasUnevenRows = true
            };
            contactList.ItemTemplate = new DataTemplate(typeof(TextCell));
            contactList.ItemTemplate.SetBinding(TextCell.TextProperty, "HeroName");

            contactList.ItemSelected += OnItemSelected;

            var newButton = new Button { Text = "Help me!" };
            newButton.Clicked += OnNewClicked;

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = 50,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label { Text = "Hello " + App.User.Name, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), FontAttributes = FontAttributes.Bold },
                    newButton,
                    contactList,
                    messageLabel
                }
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var bookings = await App.Client.InvokeApiAsync<BookingUser, ICollection<Booking>>("bookings", new BookingUser { UserId = App.User.Id });
                contactList.ItemsSource = bookings;
            }
            catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
            }
        }

        private async void OnNewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewBookingPage());
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new BookingDetailsPage((Booking)e.SelectedItem));
        }
    }
}
