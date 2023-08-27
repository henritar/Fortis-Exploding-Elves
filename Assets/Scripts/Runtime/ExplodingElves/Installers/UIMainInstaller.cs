using Assets.Scripts.Runtime.ExplodingElves.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIMainInstaller : MonoInstaller
{
    [SerializeField] public Canvas MainUICanvas;
    [SerializeField] public Button SpawnRateSettingsButton;
    [SerializeField] public Button SpawnCountSettingsButton;
    [SerializeField] public Button RestartButton;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MainsUIController>().AsSingle();
        Container.Bind<MainUIModel>().AsSingle().WhenInjectedInto<MainsUIController>();
        Container.BindInterfacesAndSelfTo<MainUIView>().FromComponentInHierarchy().AsSingle().WhenInjectedInto<MainsUIController>();

        Container.BindInstance(MainUICanvas).WithId("mainUICanvas").WhenInjectedInto<MainUIModel>();
        Container.BindInstance(SpawnRateSettingsButton).WithId("spawnRateSettingsButton").WhenInjectedInto<MainUIModel>();
        Container.BindInstance(SpawnCountSettingsButton).WithId("spawnCountSettingsButton").WhenInjectedInto<MainUIModel>();
        Container.BindInstance(RestartButton).WithId("restartButton").WhenInjectedInto<MainUIModel>();
    }
}