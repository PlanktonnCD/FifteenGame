using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UIAnimation : MonoBehaviour
    {
        [SerializeField] private float _animationDuration;
        [SerializeField] private RectTransform _panelTransform;
        
        public async UniTask ShowAnimation()
        {
            _panelTransform.position = Vector2.up * Screen.height / 2 + Vector2.up *_panelTransform.rect.height;
            _panelTransform.gameObject.SetActive(true);
            _panelTransform.DOMoveY(0, _animationDuration);
            await UniTask.Delay(TimeSpan.FromSeconds(_animationDuration));
        }

        public async UniTask HideAnimation()
        {
            var endYPosition = -(Screen.height / 2 + _panelTransform.rect.height);
            _panelTransform.DOMoveY(endYPosition, _animationDuration);
            await UniTask.Delay(TimeSpan.FromSeconds(_animationDuration));
            _panelTransform.gameObject.SetActive(false);
        }
    }
}