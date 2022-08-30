using System.Collections.Generic;
using Newtonsoft.Json;

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
        }
    }

    public struct HighScore
    {
        public string PlayerName;
        public int Minutes;
        public int Seconds;
    }
}