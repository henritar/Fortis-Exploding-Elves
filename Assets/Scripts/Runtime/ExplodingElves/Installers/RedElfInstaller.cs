using Assets.Scripts.Runtime.ExplodingElves.Elves;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class RedElfInstaller : Installer<RedElfInstaller>
    {
        [Inject]
        MainSceneInstaller.FloorSetting _floorSettings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RedElfController>().AsSingle();
            Container.Bind<RedElfModel>().AsSingle().WhenInjectedInto<RedElfController>();
            Container.Bind<RedElfView>().FromComponentOnRoot().AsSingle();
            Container.Bind<NavMeshAgent>().FromComponentOnRoot().AsSingle();
            Container.BindInstance(_floorSettings.FloorCenter).WithId("floorCenter").WhenInjectedInto<RedElfModel>().IfNotBound();
            Container.BindInstance(_floorSettings.FloorExtends).WithId("floorExtends").WhenInjectedInto<RedElfModel>().IfNotBound();

            //STATES
        }
    }
}