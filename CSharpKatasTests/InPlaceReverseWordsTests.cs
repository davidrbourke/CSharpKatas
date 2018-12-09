using CSharpKatas;
using Xunit;

namespace CSharpKatasTests
{
    public class InPlaceReverseWordsTests
    {
        [Fact]
        public void ReverseWords_TwoWordsSameLength_Reversed()
        {
            var inPlaceReverseWords = new InPlaceReverseWords();
            var result = inPlaceReverseWords.ReverseWords("cake test".ToCharArray());

            Assert.Equal("test cake".ToCharArray(), result);
        }

        [Fact]
        public void ReverseWords_FourWordsSameLength_Reversed()
        {
            var inPlaceReverseWords = new InPlaceReverseWords();
            var result = inPlaceReverseWords.ReverseWords("cake test some love".ToCharArray());

            Assert.Equal("love some test cake".ToCharArray(), result);
        }

        [Fact]
        public void ReverseWords_SingleWord_Reversed()
        {
            var inPlaceReverseWords = new InPlaceReverseWords();
            var result = inPlaceReverseWords.ReverseWords("cake".ToCharArray());

            Assert.Equal("cake".ToCharArray(), result);
        }

        [Fact]
        public void ReverseWords_WordOfDifferentLength_Reversed()
        {
            var inPlaceReverseWords = new InPlaceReverseWords();
            var result = inPlaceReverseWords.ReverseWords("landed has eagle the".ToCharArray());

            Assert.Equal("the eagle has landed".ToCharArray(), result);
        }
    }
}
