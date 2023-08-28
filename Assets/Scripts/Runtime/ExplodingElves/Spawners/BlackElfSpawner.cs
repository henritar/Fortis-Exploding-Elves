using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Explosion;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class BlackElvesSpawner : GenericElvesSpawner
    {
        public BlackElvesSpawner(BlackElfView.Factory elfFactory, SpawnPortalView.Factory blackPortalFactory,
            MainSceneInstaller.PortalSettings portalSettings, SignalBus signalBus, MainSceneInstaller.ElfSettings elvesSettings,
            MainSceneInstaller.ExplosionSettings explosionSettings, AudioPlayer audioPlayer, ExplosionView.Factory explosionFactory)
            : base(signalBus, elvesSettings, explosionSettings, audioPlayer, explosionFactory)
        {
            _elfFactory = elfFactory;
            _portalFactory = blackPortalFactory;
            _portalSettings = portalSettings;
        }
    }
}
