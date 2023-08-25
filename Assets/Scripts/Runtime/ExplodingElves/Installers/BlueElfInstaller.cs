using Assets.Scripts.Runtime.ExplodingElves.Elves;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class BlueElfInstaller : Installer<BlueElfInstaller>
    {
        [Inject]
        MainSceneInstaller.FloorSetting _floorSettings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BlueElfController>().AsSingle();
            Container.Bind<BlueElfModel>().AsSingle().WhenInjectedInto<BlueElfController>();
            Container.Bind<BlueElfView>().FromComponentOnRoot().AsSingle();
            Container.Bind<NavMeshAgent>().FromComponentOnRoot().AsSingle();
            Container.BindInstance(_floorSettings.FloorCenter).WithId("floorCenter").WhenInjectedInto<BlueElfModel>().IfNotBound();
            Container.BindInstance(_floorSettings.FloorExtends).WithId("floorExtends").WhenInjectedInto<BlueElfModel>().IfNotBound();

            //STATES
        }
    }
}