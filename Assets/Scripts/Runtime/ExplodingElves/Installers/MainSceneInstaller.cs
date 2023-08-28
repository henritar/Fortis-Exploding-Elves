using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Explosion;
using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Assets.Scripts.Runtime.ExplodingElves.Spawners;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {

        [Inject(Id = "elves")]
        MainSceneInstaller.ElfSettings[] _elvesSettings;
        [Inject(Id = "explosionSettings")]
        MainSceneInstaller.ExplosionSettings explosionSettings;


        int elvesIndex;
        public override void InstallBindings()
        {
            Container.Bind<AudioPlayer>().AsSingle();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInstance(explosionSettings).AsSingle();

            Container.BindFactory<BlackElfView, BlackElfView.Factory>().FromPoolableMemoryPool<BlackElfView, BlackElfView.BlackElfPool>(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<BlackElfInstaller>(_elvesSettings[0].ElfPrefab).UnderTransformGroup("BlackElfPool"));
            Container.BindFactory<BlueElfView, BlueElfView.Factory>().FromPoolableMemoryPool<BlueElfView, BlueElfView.BlueElfPool>(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<BlueElfInstaller>(_elvesSettings[1].ElfPrefab).UnderTransformGroup("BlueElfPool"));
            Container.BindFactory<RedElfView, RedElfView.Factory>().FromPoolableMemoryPool<RedElfView, RedElfView.RedElfPool>(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<RedElfInstaller>(_elvesSettings[2].ElfPrefab).UnderTransformGroup("RedElfPool"));
            Container.BindFactory<WhiteElfView, WhiteElfView.Factory>().FromPoolableMemoryPool<WhiteElfView, WhiteElfView.WhiteElfPool>(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<WhiteElfInstaller>(_elvesSettings[3].ElfPrefab).UnderTransformGroup("WhiteElfPool"));

            Container.BindFactory<ExplosionView, ExplosionView.Factory>()
                .FromPoolableMemoryPool<ExplosionView, ExplosionView.ExplosionPool>(poolBinder => poolBinder
                    .WithInitialSize(10).ExpandByDoubling()
                    .FromComponentInNewPrefab(explosionSettings.ExplosionPrefab)
                    .UnderTransformGroup("Explosions"));

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

        [Serializable]
        public class ElfSettings
        {
            public GameObject ElfPrefab;
            public AudioClip ElfSpawnSound;
            public string ElfName;
            public Vector2Int StartLocation;
            public int MaxSpawnQt;
        }
        [Serializable]
        public class ExplosionSettings
        {
            public GameObject ExplosionPrefab;
            public AudioClip[] ExplosionSounds;
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
            public GameObject PortalVFXPrefab;
        }
    }
}