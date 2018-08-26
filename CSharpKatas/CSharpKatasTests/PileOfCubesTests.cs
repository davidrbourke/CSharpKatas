using CSharpKatas;
using FluentAssertions;
using Xunit;

namespace CSharpKatasTests
{
    public class PileOfCubesTests
    {
        [Theory]
        [InlineData(4, 100)]
        [InlineData(2022, 4183059834009)]
        public void GetSum_ValidParams_Calculates(int levels, long expectedArea)
        {
            // Act
            double areas = PileOfCubes.GetSum(levels);

            // Assert
            areas.Should().Be(expectedArea);
        }

        [Theory]
        [InlineData(100, 4)]
        [InlineData(4183059834009, 2022)]
        [InlineData(24723578342962, -1)]
        [InlineData(1578624526782761536, 50128)]
        public void GetLevelsFromArea_ValidParams_Calculates(long area, int expectedLevels)
        {
            // Act
            long levels = PileOfCubes.GetLevels(area);

            // Assert
            levels.Should().Be(expectedLevels);
        }

        [Theory]
        [InlineData(100, 4)]
        [InlineData(4183059834009, 2022)]
        [InlineData(24723578342962, -1)]
        [InlineData(1578624526782761536, 50128)]
        public void Alt_ValidParams_Calculates(long area, int expectedLevels)
        {
            // Act
            long levels = PileOfCubes.Alt(area);

            // Assert
            levels.Should().Be(expectedLevels);
        }
    }
}
