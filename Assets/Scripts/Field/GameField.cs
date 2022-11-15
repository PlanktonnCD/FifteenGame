using System;
using System.Collections.Generic;
using DG.Tweening;
using GameBootstrap;
using RotaryHeart.Lib.SerializableDictionary;
using Spots;
using UI;
using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

namespace Field
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private List<Transform> _objectPositions = new List<Transform>();
        [SerializeField] private SpotManager _spotManager;

        private List<Spot> _spots = new List<Spot>();
        private int _currentEmptyPosition;
        private SignalBus _signalBus;
        private UIManager _uiManager;
        private bool _gameIsEnd;

        private int RowsCount => (int)Math.Sqrt(_objectPositions.Count);

        [Inject]
        private void Construct(SignalBus signalBus, UIManager uiManager)
        {
            _uiManager = uiManager;
            _signalBus = signalBus;
        }
        
        public void SpawnSpots()
        {
            _spots = _spotManager.CreateSpots(_objectPositions.Count-1);
        }

        public void SetSpots()
        {
            _gameIsEnd = false;
            var randomList = UtilsMath.GetRandomList(_spots.Count);
            while (UtilsMath.IsSolvable(randomList) == false)
            {
                randomList = UtilsMath.GetRandomList(_spots.Count);
            }
            
            for (int i = 0; i < _spots.Count; i++)
            {
                var spot = _spots[i];
                var positionNumber = randomList[i];
                spot.SetNumber(i+1);
                spot.SetCurrentPosition(positionNumber);
                spot.transform.position = _objectPositions[positionNumber].transform.position;
                spot.Button.onClick.AddListener((() => TryMoveSpot(spot)));
            }
            _currentEmptyPosition = _spots.Count;
        }

        private void TryMoveSpot(Spot spot)
        {
            if(_gameIsEnd == true) return;
            if (_currentEmptyPosition == spot.CurrentPosition + 1
                || _currentEmptyPosition == spot.CurrentPosition - 1
                || _currentEmptyPosition == spot.CurrentPosition + RowsCount
                || _currentEmptyPosition == spot.CurrentPosition - RowsCount)
            {
                spot.MoveSpot(_objectPositions[_currentEmptyPosition].transform.position);
                var newPosition = _currentEmptyPosition;
                _currentEmptyPosition = spot.CurrentPosition;
                spot.SetCurrentPosition(newPosition);
                CheckOnWin();
                return;
            }
            spot.ShakeSpot();
        }

        private void CheckOnWin()
        {
            foreach (var spot in _spots)
            {
                if (spot.CurrentPosition != spot.Number - 1) return;
            }
            WinTheGame();
        }

        private void WinTheGame()
        {
            _gameIsEnd = true;
            _signalBus.Fire(new GameEndSignal());
            _uiManager.ShowScreen<UIWinPanel>();
            
            for (int i = 0; i < _spots.Count; i++)
            {
                _spots[i].Button.onClick.RemoveAllListeners();
            }
        }
    }
}