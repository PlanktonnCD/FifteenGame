using System;
using Field;
using UnityEngine;

namespace GameBootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameField _gameField;

        private void Start()
        {
            _gameField.SpawnSpots();
            _gameField.SetSpots();
        }
    }
}