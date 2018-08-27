using CSharpKatas;
using FluentAssertions;
using Xunit;

namespace CSharpKatasTests
{
    public class SpinningWordsTests
    {
        [Theory]
        [InlineData("Hey fellow warriors", "Hey wollef sroirraw")]
        public void SpinWordsOverNLetters_ValidSentance_WordsSpun(string sentance, string expectedSentance)
        {
            // Arrange
            int n = 5;

            // Act
            var result = SpinningWords.SpinWordsOverNLetters(sentance, n);

            // Assert
            result.Should().Be(expectedSentance);
        }
    }
}
