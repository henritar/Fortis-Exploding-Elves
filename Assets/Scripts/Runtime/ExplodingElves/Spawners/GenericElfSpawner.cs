using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class GenericElvesSpawner : IInitializable
    {
        protected readonly SignalBus _signalBus;
        protected readonly MainSceneInstaller.ElfSettings _elvesSettings;
        protected IFactory<ElfView> _elfFactory;
        //readonly float _spawnRate;
        protected IDisposable coroutine;
        public GenericElvesSpawner(SignalBus signalBus, MainSceneInstaller.ElfSettings elvesSettings)
        {
            _signalBus = signalBus;
            _elvesSettings = elvesSettings;
        }

        public void Initialize()
        {

            coroutine = Observable.FromCoroutine(() => SpawnElvesCoroutine(_elvesSettings)).Subscribe();
        }

        protected IEnumerator SpawnElvesCoroutine(MainSceneInstaller.ElfSettings elfSettings)
        {
            while (true)
            {
                _elfFactory.Create();
                yield return new WaitForSeconds(elfSettings.SpawnRate);
            }
        }
    }
}
