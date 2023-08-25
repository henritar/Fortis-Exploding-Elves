using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class BlueElvesSpawner : GenericElvesSpawner
    {
        public BlueElvesSpawner(BlueElfView.Factory elfFactory, SignalBus signalBus, MainSceneInstaller.ElfSettings elvesSettings)
            : base(signalBus, elvesSettings)
        {
            _elfFactory = elfFactory;
        }
    }
}
