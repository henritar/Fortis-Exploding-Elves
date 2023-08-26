using Assets.Scripts.Runtime.ExplodingElves.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIMainInstaller : MonoInstaller
{
    [SerializeField] public Button SettingsButton;
    [SerializeField] public Button RestartButton;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MainsUIController>().AsSingle();
        Container.Bind<MainUIModel>().AsSingle().WhenInjectedInto<MainsUIController>();
        Container.BindInterfacesAndSelfTo<MainUIView>().FromComponentInHierarchy().AsSingle().WhenInjectedInto<MainsUIController>();

        Container.BindInstance(SettingsButton).WithId("settingsButton").WhenInjectedInto<MainUIModel>();
        Container.BindInstance(RestartButton).WithId("restartButton").WhenInjectedInto<MainUIModel>();
    }
}