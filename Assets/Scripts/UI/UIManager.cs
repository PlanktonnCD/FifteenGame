using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIContainer _uiContainer;
        private UIPanel _currentPanel;

        public async UniTask ShowScreen<T>() where T : UIPanel
        {
            await HideLastScreen();
            var screen = _uiContainer.GetScreen<T>();
            _currentPanel = screen;
            screen.Show();
        }

        public async UniTask HideLastScreen()
        {
            if(_currentPanel == null) return;
            await _currentPanel.Hide();
        }
    }
}