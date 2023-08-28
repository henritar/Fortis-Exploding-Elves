using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Spawners;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals.VFX;
using Assets.Scripts.Runtime.ExplodingElves.UI.Spawners.Rate;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UISpawnerRateInstaller : MonoInstaller
{
    [Inject(Id = "elves")]
    MainSceneInstaller.ElfSettings[] _elvesSettings;
    [Inject(Id = "blackSpawnPortal")]
    MainSceneInstaller.PortalSettings _blackPortalSettings;
    [Inject(Id = "blueSpawnPortal")]
    MainSceneInstaller.PortalSettings _bluePortalSettings;
    [Inject(Id = "redSpawnPortal")]
    MainSceneInstaller.PortalSettings _redPortalSettings;
    [Inject(Id = "whiteSpawnPortal")]
    MainSceneInstaller.PortalSettings _whitePortalSettings;

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
        Container.BindInterfacesAndSelfTo<BlackElvesSpawner>().AsSingle().WithArguments(_elvesSettings[0], _blackPortalSettings) ;
        Container.BindInterfacesAndSelfTo<BlueElvesSpawner>().AsSingle().WithArguments(_elvesSettings[1], _bluePortalSettings);
        Container.BindInterfacesAndSelfTo<RedElvesSpawner>().AsSingle().WithArguments(_elvesSettings[2], _redPortalSettings);
        Container.BindInterfacesAndSelfTo<WhiteElvesSpawner>().AsSingle().WithArguments(_elvesSettings[3], _whitePortalSettings);
        Container.BindInterfacesAndSelfTo<SpawnerRateUIController>().AsSingle();
        Container.Bind<SpawnerRateUIModel>().AsSingle().WhenInjectedInto<SpawnerRateUIController>();
        Container.BindInterfacesAndSelfTo<SpawnerRateUIView>().FromComponentInHierarchy().AsSingle().WhenInjectedInto<SpawnerRateUIController>();

        Container.BindFactory<UnityEngine.Object, SpawnPortalView, SpawnPortalView.Factory>().FromFactory<PrefabFactory<SpawnPortalView>>();

        Container.BindInstance(SpawnerCanvas).WithId("spawnerCanvas").WhenInjectedInto<SpawnerRateUIModel>();

        //Black Elf UI Elements
        Container.BindInstance(BlackElfNameText).WithId("blackElfNameText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(BlackElfValueText).WithId("blackElfValueText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(BlackElfDownButton).WithId("blackElfDownButton").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(BlackElfUpButton).WithId("blackElfUpButton").WhenInjectedInto<SpawnerRateUIModel>();

        //Blue Elf UI Elements
        Container.BindInstance(BlueElfNameText).WithId("blueElfNameText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(BlueElfValueText).WithId("blueElfValueText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(BlueElfDownButton).WithId("blueElfDownButton").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(BlueElfUpButton).WithId("blueElfUpButton").WhenInjectedInto<SpawnerRateUIModel>();

        //Red Elf UI Elements
        Container.BindInstance(RedElfNameText).WithId("redElfNameText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(RedElfValueText).WithId("redElfValueText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(RedElfDownButton).WithId("redElfDownButton").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(RedElfUpButton).WithId("redElfUpButton").WhenInjectedInto<SpawnerRateUIModel>();

        //White Elf UI Elements
        Container.BindInstance(WhiteElfNameText).WithId("whiteElfNameText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(WhiteElfValueText).WithId("whiteElfValueText").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(WhiteElfDownButton).WithId("whiteElfDownButton").WhenInjectedInto<SpawnerRateUIModel>();
        Container.BindInstance(WhiteElfUpButton).WithId("whiteElfUpButton").WhenInjectedInto<SpawnerRateUIModel>();

        Container.BindInstance(CloseSpawnButton).WithId("closeSpawnButton").WhenInjectedInto<SpawnerRateUIModel>();

        Container.BindFactory<BlackPortalVFXView, BlackPortalVFXView.Factory>()
                .FromPoolableMemoryPool<BlackPortalVFXView, BlackPortalVFXView.PortalVFXPool>(poolBinder => poolBinder
                    .WithInitialSize(4).ExpandByDoubling()
                    .FromComponentInNewPrefab(_blackPortalSettings.PortalVFXPrefab)
                    .UnderTransformGroup("BlackPortalVFX"));

        Container.BindFactory<BluePortalVFXView, BluePortalVFXView.Factory>()
            .FromPoolableMemoryPool<BluePortalVFXView, BluePortalVFXView.PortalVFXPool>(poolBinder => poolBinder
                .WithInitialSize(4).ExpandByDoubling()
                .FromComponentInNewPrefab(_bluePortalSettings.PortalVFXPrefab)
                .UnderTransformGroup("BluePortalVFX"));

        Container.BindFactory<RedPortalVFXView, RedPortalVFXView.Factory>()
            .FromPoolableMemoryPool<RedPortalVFXView, RedPortalVFXView.PortalVFXPool>(poolBinder => poolBinder
                .WithInitialSize(4).ExpandByDoubling()
                .FromComponentInNewPrefab(_redPortalSettings.PortalVFXPrefab)
                .UnderTransformGroup("RedPortalVFX"));

        Container.BindFactory<WhitePortalVFXView, WhitePortalVFXView.Factory>()
            .FromPoolableMemoryPool<WhitePortalVFXView, WhitePortalVFXView.PortalVFXPool>(poolBinder => poolBinder
                .WithInitialSize(4).ExpandByDoubling()
                .FromComponentInNewPrefab(_whitePortalSettings.PortalVFXPrefab)
                .UnderTransformGroup("WhitePortalVFX"));
    }
}