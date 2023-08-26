using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
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

        protected IFactory<ElfView> _elfFactory;

        protected List<ElfView> _elfPool = new List<ElfView>();
        protected List<int> CollisionHashList = new List<int>();
        protected IDisposable coroutine;
        public GenericElvesSpawner(SignalBus signalBus, MainSceneInstaller.ElfSettings elvesSettings)
        {
            _signalBus = signalBus;
            _elvesSettings = elvesSettings;
        }


        public void Initialize()
        {
            _signalBus.Subscribe<DestructiveCollisionSignal>(RemoveElf);
            _signalBus.Subscribe<GenerativeCollisionEnterSignal>(SpawnCloneElf);
            _signalBus.Subscribe<GenerativeCollisionExitSignal>(RemoveHashCollision);
            coroutine = Observable.FromCoroutine(() => SpawnElvesCoroutine(_elvesSettings)).Subscribe();
        }

        protected IEnumerator SpawnElvesCoroutine(MainSceneInstaller.ElfSettings elfSettings)
        {
            while (true)
            {
                SpawnElf();
                yield return new WaitForSeconds(elfSettings.SpawnRate);
            }
        }

        public ElfView SpawnElf()
        {
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

            if (elfView != null && elfView.CompareTag(_elvesSettings.ElfName))
            {
                
                mut.WaitOne();
                _elfPool.Remove(elfView);
                elfView.Dispose();
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
    }
}
