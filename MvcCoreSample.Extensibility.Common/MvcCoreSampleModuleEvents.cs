using System;

namespace MvcCoreSample.Extensibility.Common
{
    public class MvcCoreSampleModuleEvents
    {
        public Action<PreSubmitMovieEventArgs> PreSubmitMovie { get; set; }
        public Action<MovieSubmittedEventArgs> MovieSubmitted { get; set; }
    }
}