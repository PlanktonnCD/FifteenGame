using System;
using Field;
using Timer;
using UnityEngine;

namespace GameBootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameField _gameField;
        [SerializeField] private GameTimer _timer;

        private void Start()
        {
            _gameField.SpawnSpots();
            _gameField.SetSpots();
            _timer.SetTimer();
        }
    }
}