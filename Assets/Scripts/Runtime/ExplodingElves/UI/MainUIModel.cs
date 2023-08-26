using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.UI
{
    public class MainUIModel
    {
        [Inject(Id = "settingsButton")]
        public Button SettingsButton;

        [Inject(Id = "restartButton")]
        public Button RestartButton;
    }
}