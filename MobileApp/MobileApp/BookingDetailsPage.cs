namespace MobileApp
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class BookingDetailsPage : ContentPage
    {
        private Booking currentBooking;

        private Picker rating;

        public BookingDetailsPage(Booking booking)
        {
            this.currentBooking = booking;

            this.rating = new Picker();
            this.rating.Items.Add("0.0");
            this.rating.Items.Add("0.5");
            this.rating.Items.Add("1.0");
            this.rating.Items.Add("1.5");
            this.rating.Items.Add("2.0");
            this.rating.Items.Add("2.5");
            this.rating.Items.Add("3.0");
            this.rating.Items.Add("3.5");
            this.rating.Items.Add("4.0");
            this.rating.Items.Add("4.5");
            this.rating.Items.Add("5.0");

            for (int i = 0; i < rating.Items.Count; i++)
            {
                if (booking.Rating == double.Parse(rating.Items[i], CultureInfo.InvariantCulture))
                {
                    this.rating.SelectedIndex = i;
                    break;
                }
            }

            var button = new Button() { Text = "Rate booking" };
            button.Clicked += ButtonOnClicked;

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = 50,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label { Text = "Booking details", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), FontAttributes = FontAttributes.Bold },
                    new Label { Text = booking.HeroName },
                    new Image(),
                    new Label { Text = "Start time: " + booking.StartTime },
                    new Label { Text = "End time: " + booking.EndTime },
                    new Label { Text = booking.Description },
                    rating,
                    button
                }
            };
        }

        private async void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            try
            {
                var rate = new BookingRating { UserId = App.User.Id, Id = currentBooking.Id, Rating = double.Parse(this.rating.Items[rating.SelectedIndex], CultureInfo.InvariantCulture) };
                await App.Client.InvokeApiAsync<BookingRating, Booking>("Bookings/Rate", rate);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
