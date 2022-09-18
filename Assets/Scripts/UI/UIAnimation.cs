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
            _panelTransform.gameObject.SetActive(true);
            _panelTransform.DOScale(1, _animationDuration).From(0);
            await UniTask.Delay(TimeSpan.FromSeconds(_animationDuration));
        }

        public async UniTask HideAnimation()
        {
            _panelTransform.DOScale(0, _animationDuration);
            await UniTask.Delay(TimeSpan.FromSeconds(_animationDuration));
            _panelTransform.gameObject.SetActive(false);
        }
    }
}