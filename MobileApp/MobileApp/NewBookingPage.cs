namespace MobileApp
{
    using Xamarin.Forms;

    public class NewBookingPage : ContentPage
    {
        public NewBookingPage()
        {
            var startTime = new DatePicker();
            var endTime = new DatePicker();
            var editor = new Editor();
            var button = new Button { Text = "Create booking" };

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = 50,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label { Text = "Booking details", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), FontAttributes = FontAttributes.Bold },
                    new Label { Text = "Start time" },
                    startTime,
                    new Label { Text = "End time" },
                    endTime,
                    new Label { Text = "Description" },
                    editor,
                    button
                }
            };
        }
    }
}
