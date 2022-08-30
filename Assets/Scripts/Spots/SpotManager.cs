using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;
using Zenject;

namespace Spots
{
    public class SpotManager : MonoBehaviour
    {
        private SpotFactory _spotFactory;

        [Inject]
        private void Construct(SpotFactory spotFactory)
        {
            _spotFactory = spotFactory;
        }

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
            return _spotFactory.CreateSpot(transform);
        }
    }
}