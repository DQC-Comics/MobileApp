namespace MobileApp
{
    using System;
    using Xamarin.Forms;

    public class NewBookingPage : ContentPage
    {
        private DatePicker startTime;

        private DatePicker endTime;

        private Editor editor;

        public NewBookingPage()
        {
            startTime = new DatePicker();
            endTime = new DatePicker();
            editor = new Editor();

            var button = new Button { Text = "Create booking" };
            button.Clicked += ButtonOnClicked;

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

        private async void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            try
            {
                var booking = new BookingNew { UserId = App.User.Id, StartTime = this.startTime.Date, EndTime = this.endTime.Date, Description = this.editor.Text };
                await App.Client.InvokeApiAsync<BookingNew, Booking>("Bookings/Create", booking);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
