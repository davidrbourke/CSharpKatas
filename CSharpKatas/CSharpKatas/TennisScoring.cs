using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas
{
    public enum Point
    {
        None = 0,
        Fifteen = 1,
        Thirty = 2,
        Fourty = 3,
        Deuce = 4,
        Adv = 5
    }

    public class TennisScoring
    {
        private MatchScore _matchScore;

        public TennisScoring()
        {
            _matchScore = new MatchScore();
        }

        public MatchScore PlayMatch(string game)
        {
            foreach(var winningPlayer in game)
            {
                PlayPoint(int.Parse(winningPlayer.ToString()));
            }

            return _matchScore;
        }

        private void PlayPoint(int winningPlayer)
        {
            int winningPlayerIndex = winningPlayer - 1;
            int losingPlayerIndex = winningPlayerIndex == 0 ? 1 : 0;

            // Winning Rules
            if (_matchScore.PlayerGameScoreIndex[winningPlayerIndex] == (int)Point.Adv)
            {
                _matchScore.PlayerWinsGame(winningPlayerIndex);
                return;
            }

            if (_matchScore.PlayerGameScoreIndex[winningPlayerIndex] == (int)Point.Fourty
                && _matchScore.PlayerGameScoreIndex[losingPlayerIndex] < (int)Point.Fourty)
            {
                _matchScore.PlayerWinsGame(winningPlayerIndex);
                return;
            }

            // Deuce Rules
            if (_matchScore.PlayerGameScoreIndex[winningPlayerIndex] == (int)Point.Thirty &&
                _matchScore.PlayerGameScoreIndex[losingPlayerIndex] == (int)Point.Fourty)
            {
                _matchScore.SetDeuce();
                return;
            }

            if (_matchScore.PlayerGameScoreIndex[winningPlayerIndex] == (int)Point.Fourty &&
                _matchScore.PlayerGameScoreIndex[losingPlayerIndex] == (int)Point.Adv)
            {
                _matchScore.SetDeuce();
                return;
            }

            // Advantage Rules
            if (_matchScore.PlayerGameScoreIndex[winningPlayerIndex] == (int)Point.Deuce)
            {
                _matchScore.SetPlayerAdvantage(winningPlayerIndex);
                return;
            }

            // Normal Point
            if (_matchScore.PlayerGameScoreIndex[winningPlayerIndex] < _matchScore.GameScore.Length)
            {
                _matchScore.PlayerGameScoreIndex[winningPlayerIndex] += 1;
                return;
            }
        }
    }

    public class MatchScore
    {
        public readonly string[] GameScore;
        public int[] Player1Score { get; set; }
        public int[] PlayerGameScoreIndex { get; set; }
        public int[] PlayerAdvantageCount { get; set; }
        public int[] Player2Score { get; set; }
        
        private int _currentSet = 0;

        public MatchScore()
        {
            GameScore = new string[] { "0", "15", "30", "40", "Deuce", "Ad" };
            Player1Score = new int[] { 0, 0, 0, 0, 0 };
            Player2Score = new int[] { 0, 0, 0, 0, 0 };
            PlayerGameScoreIndex = new int[] { 0, 0 };
            PlayerAdvantageCount = new int[] { 0, 0 };
        }

        public string GetPlayerCurrentGameScore(int playerIndex)
        {
            return GameScore[PlayerGameScoreIndex[playerIndex]];
        }


        public void PlayerWinsGame(int playerIndex)
        {
            if (playerIndex == 0)
                Player1Score[_currentSet] += 1;
            else
                Player2Score[_currentSet] += 1;

            GameOver();
            UpdateCurrentSet();
        }

        public string PrintMatchScore()
        {
            var builder = new StringBuilder();
            builder.Append("Player1 ");
            foreach(var score in Player1Score)
            {
                builder.Append($"{score} ");
            }

            builder.Append("Player2 ");
            foreach(var score in Player2Score)
            {
                builder.Append($"{score} ");
            }

            if (GetMatchWinner() == 1)
                builder.Append(" Player1 Wins");

            if (GetMatchWinner() == 2)
                builder.Append(" Player2 Wins");

            if (GetMatchWinner() == 0)
                builder.Append($" {GameScore[PlayerGameScoreIndex[0]]} - {GameScore[PlayerGameScoreIndex[1]]}");

            
            return builder.ToString();
        }

        public int GetMatchWinner()
        {
            int playerOneSets = 0;
            int playerTwoSets = 0;

            for (int i = 0; i < Player1Score.Length; i++)
            {
                playerOneSets += GetSetWinner(i) == 1 ? 1 : 0;
                playerTwoSets += GetSetWinner(i) == 2 ? 1 : 0;
            }

            if (playerOneSets == 3)
                return 1;

            if (playerTwoSets == 3)
                return 2;

            return 0;
        }

        public void SetDeuce()
        {
            PlayerGameScoreIndex[0] = 4;
            PlayerGameScoreIndex[1] = 4;
        }

        public void SetPlayerAdvantage(int playerIndex)
        {
            if (playerIndex == 0)
            {
                PlayerGameScoreIndex[0] = 5;
                PlayerGameScoreIndex[1] = 3;
                PlayerAdvantageCount[0] += 1;
            }
            else
            {
                PlayerGameScoreIndex[1] = 5;
                PlayerGameScoreIndex[0] = 3;
                PlayerAdvantageCount[1] += 1;
            }
        }

        private void GameOver()
        {
            PlayerGameScoreIndex[0] = 0;
            PlayerGameScoreIndex[1] = 0;
            PlayerAdvantageCount[0] = 0;
            PlayerAdvantageCount[1] = 0;
        }

        private int GetSetWinner(int setIndex)
        {
            if (Player1Score[setIndex] >= 6 && Player2Score[setIndex] <= Player1Score[setIndex] - 2)
            {
                return 1;
            }

            if (Player2Score[setIndex] >= 6 && Player1Score[setIndex] <= Player2Score[setIndex] - 2)
            {
                return 2;
            }

            return 0;
        }

        private void UpdateCurrentSet()
        {
            if (GetSetWinner(_currentSet) != 0)
            {
                _currentSet += 1;
            }
        }
    }
}
