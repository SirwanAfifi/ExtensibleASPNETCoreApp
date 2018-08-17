using System;

namespace MvcCoreSample.Extensibility.Common
{
    public class MovieSubmittedEventArgs : EventArgs
    {
        public MovieSubmittedEventArgs(string title, int rating)
        {
            Title = title;
            Rating = rating;
        }

        public int Rating { get; set; }
        public string Title { get; set; }
    }
}