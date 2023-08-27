using Assets.Scripts.Runtime.ExplodingElves.UI.Spawners;
using Assets.Scripts.Runtime.ExplodingElves.UI.Spawners.Count;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UISpawnerCountInstaller : MonoInstaller
{
    [SerializeField] public Canvas SpawnerCanvas;

    //BlackElf UI Elements
    [SerializeField] public TextMeshProUGUI BlackElfNameText;
    [SerializeField] public TMP_InputField BlackElfValueText;

    //BlueElf UI Elements
    [SerializeField] public TextMeshProUGUI BlueElfNameText;
    [SerializeField] public TMP_InputField BlueElfValueText;

    //RedElf UI Elements
    [SerializeField] public TextMeshProUGUI RedElfNameText;
    [SerializeField] public TMP_InputField RedElfValueText;

    //WhiteElf UI Elements
    [SerializeField] public TextMeshProUGUI WhiteElfNameText;
    [SerializeField] public TMP_InputField WhiteElfValueText;

    [SerializeField] public Button CloseSpawnButton;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SpawnerCountUIController>().AsSingle();
        Container.Bind<SpawnerCountUIModel>().AsSingle().WhenInjectedInto<SpawnerCountUIController>();
        Container.BindInterfacesAndSelfTo<SpawnerCountUIView>().FromComponentInHierarchy().AsSingle().WhenInjectedInto<SpawnerCountUIController>();

        Container.BindInstance(SpawnerCanvas).WithId("spawnerCountCanvas").WhenInjectedInto<SpawnerCountUIModel>();

        //Black Elf UI Elements
        Container.BindInstance(BlackElfNameText).WithId("blackElfCountNameText").WhenInjectedInto<SpawnerCountUIModel>();
        Container.BindInstance(BlackElfValueText).WithId("blackElfCountValueField").WhenInjectedInto<SpawnerCountUIModel>();

        //Blue Elf UI Elements
        Container.BindInstance(BlueElfNameText).WithId("blueElfCountNameText").WhenInjectedInto<SpawnerCountUIModel>();
        Container.BindInstance(BlueElfValueText).WithId("blueElfCountValueField").WhenInjectedInto<SpawnerCountUIModel>();

        //Red Elf UI Elements
        Container.BindInstance(RedElfNameText).WithId("redElfCountNameText").WhenInjectedInto<SpawnerCountUIModel>();
        Container.BindInstance(RedElfValueText).WithId("redElfCountValueField").WhenInjectedInto<SpawnerCountUIModel>();

        //White Elf UI Elements
        Container.BindInstance(WhiteElfNameText).WithId("whiteElfCountNameText").WhenInjectedInto<SpawnerCountUIModel>();
        Container.BindInstance(WhiteElfValueText).WithId("whiteElfCountValueField").WhenInjectedInto<SpawnerCountUIModel>();

        Container.BindInstance(CloseSpawnButton).WithId("closeSpawnCountButton").WhenInjectedInto<SpawnerCountUIModel>();
    }
}