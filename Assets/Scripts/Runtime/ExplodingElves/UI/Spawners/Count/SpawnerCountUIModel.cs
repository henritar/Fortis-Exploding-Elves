using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.UI.Spawners.Count
{
    public class SpawnerCountUIModel
    {

        [Inject(Id = "spawnerCountCanvas")]
        public Canvas SpawnerCanvas;

        //BlackElf UI Elements
        [Inject(Id = "blackElfCountNameText")]
        public TextMeshProUGUI BlackElfNameText;
        [Inject(Id = "blackElfCountValueField")]
        public TMP_InputField BlackElfValueText;

        //BlueElf UI Elements
        [Inject(Id = "blueElfCountNameText")]
        public TextMeshProUGUI BlueElfNameText;
        [Inject(Id = "blueElfCountValueField")]
        public TMP_InputField BlueElfValueText;

        //RedElf UI Elements
        [Inject(Id = "redElfCountNameText")]
        public TextMeshProUGUI RedElfNameText;
        [Inject(Id = "redElfCountValueField")]
        public TMP_InputField RedElfValueText;

        //WhiteElf UI Elements
        [Inject(Id = "whiteElfCountNameText")]
        public TextMeshProUGUI WhiteElfNameText;
        [Inject(Id = "whiteElfCountValueField")]
        public TMP_InputField WhiteElfValueText;

        [Inject(Id = "closeSpawnCountButton")]
        public Button CloseSpawnButton;
    }
}
