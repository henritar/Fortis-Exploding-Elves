using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Explosion;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals.VFX;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class WhiteElvesSpawner : GenericElvesSpawner
    {
        public WhiteElvesSpawner(WhiteElfView.Factory elfFactory, WhitePortalVFXView.Factory portalVFXFactory, SpawnPortalView.Factory whitePortalFactory, SignalBus signalBus,
            MainSceneInstaller.ElfSettings elvesSettings, MainSceneInstaller.PortalSettings portalSettings,
            MainSceneInstaller.ExplosionSettings explosionSettings, AudioPlayer audioPlayer, ExplosionView.Factory explosionFactory)
            : base (signalBus, elvesSettings, explosionSettings, audioPlayer, explosionFactory)
        {
            _elfFactory = elfFactory;
            _portalVFXFactory = portalVFXFactory;
            _portalFactory = whitePortalFactory;
            _portalSettings = portalSettings;
            _explosionFactory = explosionFactory;
        }
    }
}
