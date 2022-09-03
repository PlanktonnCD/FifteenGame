using Cysharp.Threading.Tasks;
using PlayerData;
using Timer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UIWinPanel : UIPanel
    {
        [SerializeField] private Button _submitRecordButton;
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private TextMeshProUGUI _timeText;
        private DataManager _dataManager;
        private SignalBus _signalBus;
        private int _seconds;
        private int _minutes;
        private UIManager _uiManager;

        [Inject]
        private void Construct(DataManager dataManager, SignalBus signalBus, UIManager uiManager)
        {
            _uiManager = uiManager;
            _signalBus = signalBus;
            _dataManager = dataManager;
            _signalBus.Subscribe<SendTimerInfoSignal>(GetTimerInfo);
        }
        
        public override async UniTask Show()
        {
            await base.Show();
            _submitRecordButton.onClick.AddListener(SubmitRecord);
        }

        public override async UniTask Hide()
        {
            _submitRecordButton.onClick.RemoveAllListeners();
            await base.Hide();
        }

        private void GetTimerInfo(SendTimerInfoSignal signal)
        {
            _seconds = signal.Seconds;
            _minutes = signal.Minutes;
            _timeText.text = (_minutes.ToString("D2") + " : " + _seconds.ToString("D2"));
        }
        
        private void SubmitRecord()
        {
            _dataManager.HighScoreData.AddHighscore(_nameInput.text, _minutes, _seconds);
            _uiManager.ShowScreen<UIHighScoreTable>();
        }
    }
}