using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Explosion;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class GenericElvesSpawner : IInitializable
    {
        protected static Mutex mut = new Mutex();
        protected readonly SignalBus _signalBus;
        protected readonly MainSceneInstaller.ElfSettings _elvesSettings;
        protected readonly MainSceneInstaller.ExplosionSettings _explosionSettings;
        protected readonly AudioPlayer _audioPlayer;

        protected IFactory<ElfView> _elfFactory;
        protected SpawnPortalView.Factory _portalFactory;
        protected MainSceneInstaller.PortalSettings _portalSettings;
        protected ExplosionView.Factory _explosionFactory;

        protected List<ElfView> _elfPool = new List<ElfView>();
        protected static List<int> CollisionHashList = new List<int>();
        protected IDisposable coroutine;
        protected float SpawnRate = 1;
        protected int SpawnMaxCount;
        public GenericElvesSpawner(SignalBus signalBus, MainSceneInstaller.ElfSettings elvesSettings, MainSceneInstaller.ExplosionSettings explosionSettings,
            AudioPlayer audioPlayer, ExplosionView.Factory explosionFactory)
        {
            _signalBus = signalBus;
            _elvesSettings = elvesSettings;
            SpawnMaxCount = elvesSettings.MaxSpawnQt;
            _explosionSettings = explosionSettings;
            _audioPlayer = audioPlayer;
            _explosionFactory = explosionFactory;
        }


        public void Initialize()
        {
            _signalBus.Subscribe<DestructiveCollisionSignal>(RemoveElf);
            _signalBus.Subscribe<GenerativeCollisionEnterSignal>(SpawnCloneElf);
            _signalBus.Subscribe<GenerativeCollisionExitSignal>(RemoveHashCollision);
            _signalBus.Subscribe<IUpdateElfSpawnRate>(UpdateElfSpawnRate);
            _signalBus.Subscribe<IUpdateElfCountRate>(UpdateElfSpawnCount);
            _signalBus.Subscribe<RestartGameSignal>(RestartElvesPool);
            coroutine = Observable.FromCoroutine(() => SpawnElvesCoroutine(SpawnRate)).Subscribe();

            var portal = _portalFactory.Create(_portalSettings.ElfSpawnPortalPrefab);
            portal.transform.position = new Vector3(_elvesSettings.StartLocation.x, portal.transform.position.y, _elvesSettings.StartLocation.y);
        }

       
        protected IEnumerator SpawnElvesCoroutine(float spawnRate)
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnRate);
                SpawnElf();
            }
        }

        public ElfView SpawnElf()
        {
            if (_elfPool.Distinct().ToList().Count >= SpawnMaxCount)
                return null;

            var newElf = _elfFactory.Create();
            newElf.transform.position = new Vector3(_elvesSettings.StartLocation.x, newElf.transform.position.y, _elvesSettings.StartLocation.y);
            _elfPool.Add(newElf);
            return newElf;
        }

        public void RemoveElf(DestructiveCollisionSignal signal)
        {
            ElfView elfView = signal.Collider.CompareTag(_elvesSettings.ElfName) 
                ? signal.Collider
                : null;

            if (elfView != null)
            {
                
                mut.WaitOne();

                bool hasKey = CollisionHashList.Contains(signal.CollisionHash);

                if (hasKey)
                {
                    _audioPlayer.Play(_explosionSettings.ExplosionSounds.First());
                    var explosion = _explosionFactory.Create();
                    explosion.transform.position = new Vector3(elfView.transform.position.x, 2, elfView.transform.position.z);
                    CollisionHashList.Remove(signal.CollisionHash);
                }
                else
                {
                    CollisionHashList.Add(signal.CollisionHash);
                }

                while (_elfPool.Contains(elfView))
                {
                    _elfPool.Remove(elfView);
                    elfView.Dispose();
                }

                mut.ReleaseMutex();
            }
        }

        private void SpawnCloneElf(GenerativeCollisionEnterSignal signal)
        {
            if (!signal.ColliderPrefabTag.Equals(_elvesSettings.ElfName))
                return;
            mut.WaitOne();
            bool hasKey = CollisionHashList.Contains(signal.CollisionHash);
            
            if (!hasKey)
            {

                CollisionHashList.Add(signal.CollisionHash);
                var newElf = SpawnElf();
                
                if(newElf != null)
                    newElf.transform.position = signal.SpawnLocation;
            }
            mut.ReleaseMutex();
        }

        private void RemoveHashCollision(GenerativeCollisionExitSignal signal)
        {
            mut.WaitOne();
            CollisionHashList.Remove(signal.CollisionHash);
            mut.ReleaseMutex();
        }

        private void UpdateElfSpawnRate(IUpdateElfSpawnRate signal)
        {
            if (SpawnRate == signal.SpawnRate)
                return;
            if (_elvesSettings.ElfName == signal.ElfName)
            {
                SpawnRate = signal.SpawnRate;
                coroutine.Dispose();
                coroutine = Observable.FromCoroutine(() => SpawnElvesCoroutine(SpawnRate)).Subscribe();
            }
        }

        private void UpdateElfSpawnCount(IUpdateElfCountRate signal)
        {
            if (SpawnMaxCount == signal.SpawnCount)
                return;
            if (_elvesSettings.ElfName == signal.ElfName)
            {
                SpawnMaxCount = signal.SpawnCount;
            }
        }

        private void RestartElvesPool(RestartGameSignal signal)
        {
            coroutine.Dispose();
            while (_elfPool.Count > 0)
            {
                for (int i = 0; i < _elfPool.Count; i++)
                {
                    var elf = _elfPool[i];
                    _elfPool.Remove(elf);
                    elf.Dispose();
                }
            }
            coroutine = Observable.FromCoroutine(() => SpawnElvesCoroutine(SpawnRate)).Subscribe();
        }
    }
}
