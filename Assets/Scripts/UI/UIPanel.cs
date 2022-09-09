using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI
{
    public class UIPanel : MonoBehaviour
    {
        [SerializeField] protected UIAnimation _uiAnimation;

        public virtual void Init()
        {
            
        }
        
        public virtual async UniTask Show()
        {
            await _uiAnimation.ShowAnimation();
        }

        public virtual async UniTask Hide()
        {
            await _uiAnimation.HideAnimation();
        }
    }
}