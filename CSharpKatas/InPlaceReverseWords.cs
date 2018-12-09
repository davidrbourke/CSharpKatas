namespace CSharpKatas
{
    public class InPlaceReverseWords
    {
        public char[] ReverseWords(char[] unordered)
        {
            var i = 0;
            var j = unordered.Length - 1;
            ReverseWord(unordered, i, j);

            int prevK = 0;
            for(var k = 0; k < unordered.Length; k++)
            {
                if (unordered[k] == ' ')
                {
                    ReverseWord(unordered, prevK, k-1);
                    prevK = k+1;
                }
                else if (k == unordered.Length - 1)
                {
                    ReverseWord(unordered, prevK, k);
                }
            }

            return unordered;
        }

        private void ReverseWord(char[] unordered, int i, int j)
        {

            while (i < j)
            {
                var iVal = unordered[i];
                unordered[i] = unordered[j];
                unordered[j] = iVal;
                i++;
                j--;
            }
        }
    }
}
