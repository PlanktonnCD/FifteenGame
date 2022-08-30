using System;
using System.Collections;
using GameBootstrap;
using TMPro;
using UnityEngine;
using Zenject;

namespace Timer
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTimer;
        private bool _gameIsActive;
        private bool _gameOnPause;
        private int _seconds;
        private int _minutes;
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<GameEndSignal>(OnEndGame);
        }
        
        public void SetTimer()
        {
            _gameIsActive = true;
            _seconds = 0;
            _minutes = 0;
            StartCoroutine(TimeCount());
        }

        private void SetTimerText()
        {
            _textTimer.text = (_minutes.ToString("D2") + " : " + _seconds.ToString("D2"));
        }

        private void OnEndGame()
        {
            _gameIsActive = false;
        }
        
        private IEnumerator TimeCount()
        {
            while (_gameIsActive)
            {
                while (_gameOnPause == false)
                {
                    yield return new WaitForSeconds(1);
                    _seconds++;
                    if (_seconds == 60)
                    {
                        _minutes++;
                        _seconds = 0;
                    }
                    SetTimerText();
                } 
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _gameOnPause = pauseStatus;
        }
    }
}