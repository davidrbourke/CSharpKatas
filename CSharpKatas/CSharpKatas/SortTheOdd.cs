using System.Linq;

namespace CSharpKatas
{
    public class SortTheOdd
    {
        public static int[] Sort(int[] array)
        {
            var odds = array
                .Where(inp => inp % 2 != 0)
                .OrderBy(inp => inp)
                .ToArray();

            int posOfOdds = 0;
            return array
                .Select(
                    a => a % 2 == 0 ? a : odds[posOfOdds++]
                ).ToArray();
        }
    }
}
