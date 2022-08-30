using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Field
{
    public class Spot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numberText;
        private int _number;
        private int _currentPosition;
        
        public void SetNumber(int number)
        {
            _number = number;
            _numberText.text = _number.ToString();
        }
    }
}