using Assets.Scripts.Runtime.ExplodingElves.Elves;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class BlackElfInstaller : Installer<BlackElfInstaller>
    {
        [Inject]
        MainSceneInstaller.FloorSetting _floorSettings;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BlackElfController>().AsSingle();
            Container.Bind<BlackElfModel>().AsSingle().WhenInjectedInto<BlackElfController>();
            Container.Bind<BlackElfView>().FromComponentOnRoot().AsSingle();
            Container.Bind<NavMeshAgent>().FromComponentOnRoot().AsSingle();
            Container.BindInstance(_floorSettings.FloorCenter).WithId("floorCenter").WhenInjectedInto<BlackElfModel>().IfNotBound();
            Container.BindInstance(_floorSettings.FloorExtends).WithId("floorExtends").WhenInjectedInto<BlackElfModel>().IfNotBound();

            //STATES
        }
    }
}