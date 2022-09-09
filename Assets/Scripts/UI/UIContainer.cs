using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class UIContainer
    {
        [SerializeField] private List<UIPanel> _uiScreens;

        public UIPanel GetScreen<T>() where T : UIPanel
        {
            foreach (var uiScreen in _uiScreens)
            {
                if (uiScreen is T)
                {
                    uiScreen.Init();
                    return uiScreen;
                }
            }

            return null;
        }
    }
}