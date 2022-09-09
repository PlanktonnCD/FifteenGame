using System;
using Field;
using PlayerData;
using Timer;
using UI;
using UnityEngine;
using Zenject;

namespace GameBootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameField _gameField;
        [SerializeField] private GameTimer _timer;
        private DataManager _dataManager;
        private SignalBus _signalBus;
        private UIManager _uiManager;

        [Inject]
        private void Construct(DataManager dataManager, SignalBus signalBus, UIManager uiManager)
        {
            _uiManager = uiManager;
            _signalBus = signalBus;
            _dataManager = dataManager;
            _signalBus.Subscribe<RestartGameSignal>(RestartGame);
        }
        
        private void Start()
        {
            _dataManager.ReadData();
            _gameField.SpawnSpots();
            _gameField.SetSpots();
            _timer.SetTimer();
        }

        private void RestartGame()
        {
            _uiManager.HideLastScreen();
            _gameField.SetSpots();
            _timer.SetTimer();
        }

        private void OnApplicationQuit()
        {
            _dataManager.SaveData();
        }
    }
}