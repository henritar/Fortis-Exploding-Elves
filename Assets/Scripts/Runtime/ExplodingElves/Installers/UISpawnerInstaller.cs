using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Spawners;
using Assets.Scripts.Runtime.ExplodingElves.UI.Spawners;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UISpawnerInstaller : MonoInstaller
{
    [Inject(Id = "elves")]
    MainSceneInstaller.ElfSettings[] _elvesSettings;

    [SerializeField] public Canvas SpawnerCanvas;

    //BlackElf UI Elements
    [SerializeField] public TextMeshProUGUI BlackElfNameText;
    [SerializeField] public TextMeshProUGUI BlackElfValueText;
    [SerializeField] public Button BlackElfDownButton;
    [SerializeField] public Button BlackElfUpButton;

    //BlueElf UI Elements
    [SerializeField] public TextMeshProUGUI BlueElfNameText;
    [SerializeField] public TextMeshProUGUI BlueElfValueText;
    [SerializeField] public Button BlueElfDownButton;
    [SerializeField] public Button BlueElfUpButton;

    //RedElf UI Elements
    [SerializeField] public TextMeshProUGUI RedElfNameText;
    [SerializeField] public TextMeshProUGUI RedElfValueText;
    [SerializeField] public Button RedElfDownButton;
    [SerializeField] public Button RedElfUpButton;

    //WhiteElf UI Elements
    [SerializeField] public TextMeshProUGUI WhiteElfNameText;
    [SerializeField] public TextMeshProUGUI WhiteElfValueText;
    [SerializeField] public Button WhiteElfDownButton;
    [SerializeField] public Button WhiteElfUpButton;

    [SerializeField] public Button CloseSpawnButton;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BlackElvesSpawner>().AsSingle().WithArguments(_elvesSettings[0]);
        Container.BindInterfacesAndSelfTo<BlueElvesSpawner>().AsSingle().WithArguments(_elvesSettings[1]);
        Container.BindInterfacesAndSelfTo<RedElvesSpawner>().AsSingle().WithArguments(_elvesSettings[2]);
        Container.BindInterfacesAndSelfTo<WhiteElvesSpawner>().AsSingle().WithArguments(_elvesSettings[3]);
        Container.BindInterfacesAndSelfTo<SpawnerUIController>().AsSingle();
        Container.Bind<SpawnerUIModel>().AsSingle().WhenInjectedInto<SpawnerUIController>();
        Container.BindInterfacesAndSelfTo<SpawnerUIView>().FromComponentInHierarchy().AsSingle().WhenInjectedInto<SpawnerUIController>();

        Container.BindInstance(SpawnerCanvas).WithId("spawnerCanvas").WhenInjectedInto<SpawnerUIModel>();

        //Black Elf UI Elements
        Container.BindInstance(BlackElfNameText).WithId("blackElfNameText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(BlackElfValueText).WithId("blackElfValueText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(BlackElfDownButton).WithId("blackElfDownButton").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(BlackElfUpButton).WithId("blackElfUpButton").WhenInjectedInto<SpawnerUIModel>();

        //Blue Elf UI Elements
        Container.BindInstance(BlueElfNameText).WithId("blueElfNameText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(BlueElfValueText).WithId("blueElfValueText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(BlueElfDownButton).WithId("blueElfDownButton").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(BlueElfUpButton).WithId("blueElfUpButton").WhenInjectedInto<SpawnerUIModel>();

        //Red Elf UI Elements
        Container.BindInstance(RedElfNameText).WithId("redElfNameText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(RedElfValueText).WithId("redElfValueText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(RedElfDownButton).WithId("redElfDownButton").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(RedElfUpButton).WithId("redElfUpButton").WhenInjectedInto<SpawnerUIModel>();

        //White Elf UI Elements
        Container.BindInstance(WhiteElfNameText).WithId("whiteElfNameText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(WhiteElfValueText).WithId("whiteElfValueText").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(WhiteElfDownButton).WithId("whiteElfDownButton").WhenInjectedInto<SpawnerUIModel>();
        Container.BindInstance(WhiteElfUpButton).WithId("whiteElfUpButton").WhenInjectedInto<SpawnerUIModel>();

        Container.BindInstance(CloseSpawnButton).WithId("closeSpawnButton").WhenInjectedInto<SpawnerUIModel>();
    }
}