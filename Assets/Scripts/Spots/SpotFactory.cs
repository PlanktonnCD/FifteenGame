using UnityEngine;
using Zenject;

namespace Spots
{
    public class SpotFactory
    {
        private DiContainer _container;
        private Spot _spotPrefab;

        public SpotFactory(DiContainer container, Spot spotPrefab)
        {
            _spotPrefab = spotPrefab;
            _container = container;
        }

        public Spot CreateSpot(Transform parent)
        {
            return _container.InstantiatePrefab(_spotPrefab, parent).GetComponent<Spot>();
        }
    }
}