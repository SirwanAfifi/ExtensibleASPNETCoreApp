using MvcCoreSample.Extensibility.Common;

namespace MvcCoreSample.Extensibility.TheChapel
{
    public class ProfanityCheck : ICoreModule
    {
        private string[] _badWords;

        public ProfanityCheck()
        {
            _badWords = GetProfanityWords();
        }
        
        public void Initialize(MvcCoreSampleModuleEvents moduleEvents)
        {
            moduleEvents.PreSubmitMovie += OnPreSubmitMovie;
        }

        private void OnPreSubmitMovie(PreSubmitMovieEventArgs e)
        {
            e.Title = RemoveProfanity(e.Title);
        }

        private string RemoveProfanity(string text)
        {
            string newText = text;

            foreach (var badWord in _badWords)
                newText = newText.Replace(badWord, "$%!@&*#$");

            return newText;
        }

        private string[] GetProfanityWords()
        {
            return new string[]
            {
                "filth", "flarn"
            };
        }
    }
}