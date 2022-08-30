using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Spots
{
    public class Spot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberText;
        [SerializeField] private Button _button;
        private int _number;
        private int _currentPosition;

        public Button Button => _button;
        public int CurrentPosition => _currentPosition;

        public void SetCurrentPosition(int position)
        {
            _currentPosition = position;
        }
        
        public void SetNumber(int number)
        {
            _number = number;
            _numberText.text = _number.ToString();
        }
    }
}