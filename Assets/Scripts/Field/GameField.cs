using System;
using System.Collections.Generic;
using DG.Tweening;
using GameBootstrap;
using RotaryHeart.Lib.SerializableDictionary;
using Spots;
using UnityEngine;
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

        private int RowsCount => (int)Math.Sqrt(_objectPositions.Count);

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void SpawnSpots()
        {
            _spots = _spotManager.CreateSpots(_objectPositions.Count-1);
        }

        public void SetSpots()
        {
            var randomList = GetRandomList();
            for (int i = 0; i < _spots.Count; i++)
            {
                var spot = _spots[i];
                var positionNumber = randomList[i];
                spot.SetNumber(i+1);
                spot.SetCurrentPosition(positionNumber);
                spot.transform.DOMove( _objectPositions[positionNumber].transform.position,0.2f );
                spot.Button.onClick.AddListener((() => TryMoveSpot(spot)));
            }

            _currentEmptyPosition = _spots.Count;
        }

        private void TryMoveSpot(Spot spot)
        {
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
            }
        }

        private void CheckOnWin()
        {
            foreach (var spot in _spots)
            {
                if (spot.CurrentPosition != spot.Number) return;
                WinTheGame();
            }
        }

        private void WinTheGame()
        {
            _signalBus.Fire(new GameEndSignal());
        }
        
        private List<int> GetRandomList()
        {
            var randomList = new List<int>();
            for (int i = 0; i < _spots.Count; i++)
            {
                var randomNumber = Random.Range(0, _spots.Count);
                while (randomList.Contains(randomNumber))
                {
                    randomNumber = Random.Range(0, _spots.Count);
                }
                randomList.Add(randomNumber);
            }
            return randomList;
        }
    }
}