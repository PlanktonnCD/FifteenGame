using System;
using Cysharp.Threading.Tasks;
using GameBootstrap;
using PlayerData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UIHighScoreTable : UIPanel
    {
        [SerializeField] private TextMeshProUGUI _highScoresText;
        [SerializeField] private Button _restartGameButton;
        private DataManager _dataManager;
        private SignalBus _signalBus;

        [Inject]
        private void Construct(DataManager dataManager, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _dataManager = dataManager;
        }

        public override async UniTask Show()
        {
            await base.Show();
            SetAllRecords();
            _restartGameButton.onClick.AddListener(()=>_signalBus.Fire(new RestartGameSignal()));
        }

        public override async UniTask Hide()
        {
            await base.Hide();
        }

        private void SetAllRecords()
        {
            _highScoresText.text = String.Empty;
            foreach (var highScore in _dataManager.HighScoreData.HighScores)
            {
                _highScoresText.text += highScore.PlayerName.ToString() + "  " + highScore.Minutes.ToString("D2") + " : " +
                                        highScore.Seconds.ToString("D2") + "\n";
            }
        }
    }
}