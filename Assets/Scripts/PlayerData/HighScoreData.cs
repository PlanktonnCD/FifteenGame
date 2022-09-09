using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace PlayerData
{
    public class HighScoreData
    {
        [JsonProperty] private List<HighScore> _highScores = new List<HighScore>();
        [JsonIgnore] public List<HighScore> HighScores => _highScores;

        public void AddHighscore(string playerName, int minutes, int seconds)
        {
            var highScore = new HighScore();
            highScore.PlayerName = playerName;
            highScore.Minutes = minutes;
            highScore.Seconds = seconds;
            _highScores.Add(highScore);
            SortHighScores();
        }
        
        private void SortHighScores()
        {
            for (int i = 0; i < _highScores.Count; i++)
            {
                var highScore = _highScores[i];
                var j = i;
                var seconds = highScore.Seconds;
                seconds += highScore.Minutes * 60;
                while ((j>=1) &&(_highScores[j-1].Minutes*60 + _highScores[j-1].Seconds > seconds))
                {
                    var temp = _highScores[j];
                    _highScores[j] = _highScores[j-1];
                    _highScores[j-1] = temp;
                    j--;
                }
                _highScores[j] = highScore;
            }
        }
    }

    public struct HighScore
    {
        public string PlayerName;
        public int Minutes;
        public int Seconds;
    }
}