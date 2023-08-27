using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.UI.Spawners.Rate
{
    public class SpawnerRateUIModel
    {

        [Inject(Id = "spawnerCanvas")]
        public Canvas SpawnerCanvas;

        //BlackElf UI Elements
        [Inject(Id = "blackElfNameText")]
        public TextMeshProUGUI BlackElfNameText;
        [Inject(Id = "blackElfValueText")]
        public TextMeshProUGUI BlackElfValueText;
        [Inject(Id = "blackElfDownButton")]
        public Button BlackElfDownButton;
        [Inject(Id = "blackElfUpButton")]
        public Button BlackElfUpButton;

        //BlueElf UI Elements
        [Inject(Id = "blueElfNameText")]
        public TextMeshProUGUI BlueElfNameText;
        [Inject(Id = "blueElfValueText")]
        public TextMeshProUGUI BlueElfValueText;
        [Inject(Id = "blueElfDownButton")]
        public Button BlueElfDownButton;
        [Inject(Id = "blueElfUpButton")]
        public Button BlueElfUpButton;

        //RedElf UI Elements
        [Inject(Id = "redElfNameText")]
        public TextMeshProUGUI RedElfNameText;
        [Inject(Id = "redElfValueText")]
        public TextMeshProUGUI RedElfValueText;
        [Inject(Id = "redElfDownButton")]
        public Button RedElfDownButton;
        [Inject(Id = "redElfUpButton")]
        public Button RedElfUpButton;

        //WhiteElf UI Elements
        [Inject(Id = "whiteElfNameText")]
        public TextMeshProUGUI WhiteElfNameText;
        [Inject(Id = "whiteElfValueText")]
        public TextMeshProUGUI WhiteElfValueText;
        [Inject(Id = "whiteElfDownButton")]
        public Button WhiteElfDownButton;
        [Inject(Id = "whiteElfUpButton")]
        public Button WhiteElfUpButton;

        [Inject(Id = "closeSpawnButton")]
        public Button CloseSpawnButton;
    }
}
