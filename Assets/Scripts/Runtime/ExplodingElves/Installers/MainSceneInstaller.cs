using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {

        [Inject(Id = "elves")]
        MainSceneInstaller.ElfSettings[] _elvesSettings;
        

        int elvesIndex;
        public override void InstallBindings()
        {
            
            Container.BindFactory<BlackElfView, BlackElfView.Factory>().FromMonoPoolableMemoryPool(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<BlackElfInstaller>(_elvesSettings[0].ElfPrefab).UnderTransformGroup("BlackElfPool"));
            Container.BindFactory<BlueElfView, BlueElfView.Factory>().FromMonoPoolableMemoryPool(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<BlueElfInstaller>(_elvesSettings[1].ElfPrefab).UnderTransformGroup("BlueElfPool"));
            Container.BindFactory<RedElfView, RedElfView.Factory>().FromMonoPoolableMemoryPool(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<RedElfInstaller>(_elvesSettings[2].ElfPrefab).UnderTransformGroup("RedElfPool"));
            Container.BindFactory<WhiteElfView, WhiteElfView.Factory>().FromMonoPoolableMemoryPool(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<WhiteElfInstaller>(_elvesSettings[3].ElfPrefab).UnderTransformGroup("WhiteElfPool"));

           

            Container.Bind<string>().FromInstance(_elvesSettings[0].ElfName)
                    .WhenInjectedInto<BlackElfModel>();
            Container.Bind<string>().FromInstance(_elvesSettings[1].ElfName)
                    .WhenInjectedInto<BlueElfModel>();
            Container.Bind<string>().FromInstance(_elvesSettings[2].ElfName)
                    .WhenInjectedInto<RedElfModel>();
            Container.Bind<string>().FromInstance(_elvesSettings[3].ElfName)
                    .WhenInjectedInto<WhiteElfModel>();

            Container.Bind<Vector2Int>().FromInstance(_elvesSettings[0].StartLocation)
                    .WhenInjectedInto<BlackElfModel>();
            Container.Bind<Vector2Int>().FromInstance(_elvesSettings[1].StartLocation)
                    .WhenInjectedInto<BlueElfModel>();
            Container.Bind<Vector2Int>().FromInstance(_elvesSettings[2].StartLocation)
                    .WhenInjectedInto<RedElfModel>();
            Container.Bind<Vector2Int>().FromInstance(_elvesSettings[3].StartLocation)
                    .WhenInjectedInto<WhiteElfModel>();

        }

        //private UnityEngine.Object SelectElfPrefab(InjectContext context)
        //{
        //    ElfSettings settings = _elvesSettings[elvesIndex % _elvesSettings.Length];

        //    Container.Rebind<string>().FromInstance(settings.ElfName)
        //            .WhenInjectedInto<ElfModel>();

        //    Container.Rebind<Vector2Int>().FromInstance(settings.StartTile)
        //            .WhenInjectedInto<ElfModel>();

        //    return _elvesSettings[elvesIndex++ % _elvesSettings.Length].ElfPrefab;
        //}

        [Serializable]
        public class ElfSettings
        {
            public GameObject ElfPrefab;
            
            public string ElfName;
            public Vector2Int StartLocation;
            public int MaxSpawnQt;
        }

        [Serializable]
        public class FloorSetting
        {
            public float FloorCenter;
            public float FloorExtends;
        }

        [Serializable]
        public class PortalSettings
        {
            public GameObject ElfSpawnPortalPrefab;
        }
    }
}