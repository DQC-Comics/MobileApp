namespace MobileApp
{
    using System;

    public class Booking
    {
        public int Id { get; set; }

        public string HeroName { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public double Rating { get; set; }
    }
}
