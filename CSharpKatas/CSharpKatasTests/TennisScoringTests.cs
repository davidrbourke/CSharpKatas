using CSharpKatas;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpKatasTests
{
    public class TennisScoringTests
    {
        [Fact]
        public void PlayTennis_PlayPoint_PlayerOne()
        {
            string game = "111";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("40", result.GetPlayerCurrentGameScore(0));
        }

        [Fact]
        public void PlayTennis_PlayPoint_PlayerTwo()
        {
            string game = "222";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("40", result.GetPlayerCurrentGameScore(1));
        }

        [Fact]
        public void PlayTennis_PlayPoint_PlayerOneWinsAGame()
        {
            string game = "111221";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("0", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("0", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(1, result.Player1Score[0]);
            Assert.Equal(0, result.Player2Score[0]);
        }

        [Fact]
        public void PlayTennis_PlayPoint_PlayerTwoWinsAGame()
        {
            string game = "222112";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("0", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("0", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(0, result.Player1Score[0]);
            Assert.Equal(1, result.Player2Score[0]);
        }


        [Fact]
        public void PlayTennis_PlayPoint_PlayerOneWinsASet()
        {
            string game = "111221111221111221111221111221111221";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("0", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("0", result.GetPlayerCurrentGameScore(0));
            Assert.Equal(6, result.Player1Score[0]);
            Assert.Equal(0, result.Player2Score[0]);
        }

        [Fact]
        public void PlayTennis_PlayPoint_PlayerOneWinsASetAndLeadsSecondSet()
        {
            string game = "111221111221111221111221111221111221111221";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("0", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("0", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(6, result.Player1Score[0]);
            Assert.Equal(0, result.Player2Score[0]);
            Assert.Equal(1, result.Player1Score[1]);
            Assert.Equal(0, result.Player2Score[1]);

            var scoreOutput = result.PrintMatchScore();
        }

        [Fact]
        public void PlayTennis_PlayPoint_2SetsEach3030()
        {
            string set1 = "111221111221111221111221222112222112222112222112111221111221"; // 6 - 4
            string set2 = "222112222112222112222112111221111221222112222112"; // 2 - 6
            string set3 = "111221111221111221111221222112222112222112222112111221111221"; // 6 - 4
            string set4 = "222112222112222112222112111221111221222112222112"; // 2 - 6
            string set5 = "1122"; // 0-0 30-30

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(set1 + set2 + set3 + set4 + set5);

            Assert.Equal("30", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("30", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(6, result.Player1Score[0]);
            Assert.Equal(4, result.Player2Score[0]);

            Assert.Equal(2, result.Player1Score[1]);
            Assert.Equal(6, result.Player2Score[1]);

            Assert.Equal(6, result.Player1Score[2]);
            Assert.Equal(4, result.Player2Score[2]);

            Assert.Equal(2, result.Player1Score[3]);
            Assert.Equal(6, result.Player2Score[3]);

            Assert.Equal(0, result.Player1Score[4]);
            Assert.Equal(0, result.Player2Score[4]);

            var scoreOutput = result.PrintMatchScore();
        }

        [Fact]
        public void PlayTennis_PlayPoint_PlayerOneWinsMatch()
        {
            string set1 = "111221111221111221111221222112222112222112222112111221111221"; // 6 - 4
            string set2 = "222112222112222112222112111221111221222112222112"; // 2 - 6
            string set3 = "111221111221111221111221222112222112222112222112111221111221"; // 6 - 4
            string set4 = "222112222112222112222112111221111221222112222112"; // 2 - 6
            string set5 = "111221111221111221111221222112222112222112222112111221111221"; // 6 - 4

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(set1 + set2 + set3 + set4 + set5);

            Assert.Equal("0", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("0", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(6, result.Player1Score[0]);
            Assert.Equal(4, result.Player2Score[0]);

            Assert.Equal(2, result.Player1Score[1]);
            Assert.Equal(6, result.Player2Score[1]);

            Assert.Equal(6, result.Player1Score[2]);
            Assert.Equal(4, result.Player2Score[2]);

            Assert.Equal(2, result.Player1Score[3]);
            Assert.Equal(6, result.Player2Score[3]);

            Assert.Equal(6, result.Player1Score[4]);
            Assert.Equal(4, result.Player2Score[4]);

            var scoreOutput = result.PrintMatchScore();
        }

        [Fact]
        public void PlayTennis_PlayPoint_PlayerOneWinsASet7_5()
        {
            string set1 = "111221111221111221111221222112222112222112222112222112111221111221111221";
            //string set2 = "1112211112211112211112212221122221122221122221122221121112211112212";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(set1);

            Assert.Equal("0", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("0", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(7, result.Player1Score[0]);
            Assert.Equal(5, result.Player2Score[0]);

            var scoreOutput = result.PrintMatchScore();
        }

        [Fact]
        public void PlayTennis_PlayPoint_Deuce()
        {
            string game = "121212";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("Deuce", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("Deuce", result.GetPlayerCurrentGameScore(1));
        }

        [Fact]
        public void PlayTennis_PlayPoint_PlayerOneAdvantage()
        {
            string game = "1212121";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("Ad", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("40", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(1, result.PlayerAdvantageCount[0]);
            Assert.Equal(0, result.PlayerAdvantageCount[1]);
        }

        [Fact]
        public void PlayTennis_PlayPoint_DeuceAfterAdvantage()
        {
            string game = "12121212";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("Deuce", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("Deuce", result.GetPlayerCurrentGameScore(1));
        }

        [Fact]
        public void PlayTennis_PlayPoint_2AdvantagesEach()
        {
            string game = "12121212122121";

            var tennisScoring = new TennisScoring();
            var result = tennisScoring.PlayMatch(game);

            Assert.Equal("Deuce", result.GetPlayerCurrentGameScore(0));
            Assert.Equal("Deuce", result.GetPlayerCurrentGameScore(1));
            Assert.Equal(2, result.PlayerAdvantageCount[0]);
            Assert.Equal(2, result.PlayerAdvantageCount[1]);
        }
    }
}
