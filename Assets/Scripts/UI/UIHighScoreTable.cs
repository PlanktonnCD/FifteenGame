using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI
{
    public class UIHighScoreTable : UIPanel
    {
        public override async UniTask Show()
        {
            await base.Show();
        }

        public override async UniTask Hide()
        {
            await base.Hide();
        }
    }
}