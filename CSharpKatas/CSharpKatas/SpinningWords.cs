using System.Linq;

namespace CSharpKatas
{
    public class SpinningWords
    {
        public static string SpinWordsOverNLetters(string sentence, int n)
        {
            return string.Join(" ", sentence.Split(' ')
                .Select(w => w.Length >= n ? string.Join("", w.Reverse()) : w));
        }
    }
}
