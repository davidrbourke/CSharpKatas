using CSharpKatas;
using FluentAssertions;
using Xunit;

namespace CSharpKatasTests
{
    public class SortTheOddTests
    {
        [Fact]
        public void Sort_ValidInput_SortedOddsReturned()
        {
            // Arrange
            var input = new int[] { 5, 3, 2, 8, 1, 4 };
            var output = new int[] { 1, 3, 2, 8, 5, 4 };

            // Act
            var result = SortTheOdd.Sort(input);

            // Assert
            result.Should().BeEquivalentTo(output);
        }
    }
}
