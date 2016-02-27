namespace MobileApp
{
    using Xamarin.Forms;

    public class BookingDetailsPage : ContentPage
    {
        public BookingDetailsPage(Booking booking)
        {
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
                    new Picker { }
                }
            };
        }
    }
}
