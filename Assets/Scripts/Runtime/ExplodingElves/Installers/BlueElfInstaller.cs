using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using static Assets.Scripts.Runtime.ExplodingElves.Installers.MainSceneInstaller;

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
            Container.Bind<Rigidbody>().FromComponentOnRoot().AsSingle();
            Container.Bind<Collider>().FromComponentOnRoot().AsSingle();
            Container.BindInstance(_floorSettings.FloorCenter).WithId("floorCenter").WhenInjectedInto<BlueElfModel>().IfNotBound();
            Container.BindInstance(_floorSettings.FloorExtends).WithId("floorExtends").WhenInjectedInto<BlueElfModel>().IfNotBound();

            //STATES
        }
    }
}