using DG.Tweening;
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
        [SerializeField] private float _animationDuration;
        private int _number;
        private int _currentPosition;
        private static float _shakePower = 0.02f;

        public Button Button => _button;
        public int CurrentPosition => _currentPosition;
        public int Number => _number;

        public void MoveSpot(Vector3 position)
        {
            transform.DOMove(position, _animationDuration);
        }

        public void ShakeSpot()
        {
            transform.DOShakePosition(_animationDuration, _shakePower);
        }
        
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