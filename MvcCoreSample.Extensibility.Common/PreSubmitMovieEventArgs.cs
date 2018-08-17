using System.ComponentModel;

namespace MvcCoreSample.Extensibility.Common
{
    public class PreSubmitMovieEventArgs : CancelEventArgs
    {
        public PreSubmitMovieEventArgs(string title, int rating)
        {
            Title = title;
            Rating = rating;
        }

        public int Rating { get; set; }
        public string Title { get; set; }
        public string ModelErrorProperty { get; set; }
        public string ModelErrorMessage { get; set; }
    }
}