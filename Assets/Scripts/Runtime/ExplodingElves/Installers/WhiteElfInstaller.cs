using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class WhiteElfInstaller : Installer<WhiteElfInstaller>
    {
        [Inject]
        MainSceneInstaller.FloorSetting _floorSettings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WhiteElfController>().AsSingle();
            Container.Bind<WhiteElfModel>().AsSingle().WhenInjectedInto<WhiteElfController>();
            Container.Bind<WhiteElfView>().FromComponentOnRoot().AsSingle();
            Container.Bind<NavMeshAgent>().FromComponentOnRoot().AsSingle();
            Container.Bind<Rigidbody>().FromComponentOnRoot().AsSingle();
            Container.Bind<Collider>().FromComponentOnRoot().AsSingle();
            Container.BindInstance(_floorSettings.FloorCenter).WithId("floorCenter").WhenInjectedInto<WhiteElfModel>().IfNotBound();
            Container.BindInstance(_floorSettings.FloorExtends).WithId("floorExtends").WhenInjectedInto<WhiteElfModel>().IfNotBound();

            //STATES
        }
    }
}