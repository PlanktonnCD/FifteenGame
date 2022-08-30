using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Field
{
    public class GameField : MonoBehaviour
    {
        [SerializeField]
        private SerializableDictionaryBase<int, Transform> _objectPositions =
            new SerializableDictionaryBase<int, Transform>();
        private List<Spot> _spots = new List<Spot>();
    }
}