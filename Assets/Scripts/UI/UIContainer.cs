using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIContainer : MonoBehaviour
    {
        [SerializeField] private List<UIPanel> _uiScreens;

        public UIPanel GetScreen<T>() where T : UIPanel
        {
            foreach (var uiScreen in _uiScreens)
            {
                if (uiScreen is T)
                {
                    return uiScreen;
                }
            }

            return null;
        }
    }
}