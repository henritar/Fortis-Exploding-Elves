using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.UI
{
    public class MainUIModel
    {
        [Inject(Id = "mainUICanvas")]
        public Canvas MainUICanvas;
        [Inject(Id = "spawnRateSettingsButton")]
        public Button SpawnRateSettingsButton;
        [Inject(Id = "spawnCountSettingsButton")]
        public Button SpawnCountSettingsButton;
        [Inject(Id = "restartButton")]
        public Button RestartButton;

    }
}