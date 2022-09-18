using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;
using Utils;
using Zenject;

namespace Spots
{
    public class SpotManager : MonoBehaviour
    {
        [SerializeField] private Spot _spotPrefab;
        
        public List<Spot> CreateSpots(int numberOfSpots)
        {
            var spotList = new List<Spot>();
            for (int i = 0; i < numberOfSpots; i++)
            {
                var spot = GetSpot();
                spot.SetNumber(i+1);
                spotList.Add(spot);
            }

            return spotList;
        }
        

        private Spot GetSpot()
        {
            return Instantiate(_spotPrefab, transform).GetComponent<Spot>();
        }
        
        
    }
}