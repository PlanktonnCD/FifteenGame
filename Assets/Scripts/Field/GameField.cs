using System.Collections.Generic;
using DG.Tweening;
using RotaryHeart.Lib.SerializableDictionary;
using Spots;
using UnityEngine;

namespace Field
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private List<Transform> _objectPositions = new List<Transform>();
        [SerializeField] private SpotManager _spotManager;
        
        private List<Spot> _spots = new List<Spot>();
        private int _currentEmptyPosition;

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
                spot.transform.position = _objectPositions[positionNumber].transform.position;
                spot.Button.onClick.AddListener((() => TryMoveSpot(spot)));
            }

            _currentEmptyPosition = _spots.Count;
        }

        private void TryMoveSpot(Spot spot)
        {
            if (_currentEmptyPosition == spot.CurrentPosition + 1
                || _currentEmptyPosition == spot.CurrentPosition - 1
                || _currentEmptyPosition == spot.CurrentPosition + 4
                || _currentEmptyPosition == spot.CurrentPosition - 4)
            {

                spot.transform.DOMove(_objectPositions[_currentEmptyPosition].position, 0.5f);
                var newPosition = _currentEmptyPosition;
                _currentEmptyPosition = spot.CurrentPosition;
                spot.SetCurrentPosition(newPosition);
            }
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