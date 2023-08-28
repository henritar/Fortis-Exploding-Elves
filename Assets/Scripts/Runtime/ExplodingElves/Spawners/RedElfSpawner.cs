using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Explosion;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class RedElvesSpawner : GenericElvesSpawner
    {
        public RedElvesSpawner(RedElfView.Factory elfFactory, SpawnPortalView.Factory redPortalFactory, SignalBus signalBus,
            MainSceneInstaller.ElfSettings elvesSettings, MainSceneInstaller.PortalSettings portalSettings,
            MainSceneInstaller.ExplosionSettings explosionSettings, AudioPlayer audioPlayer, ExplosionView.Factory explosionFactory)
            : base(signalBus, elvesSettings, explosionSettings, audioPlayer, explosionFactory)
        {
            _elfFactory = elfFactory;
            _portalFactory = redPortalFactory;
            _portalSettings = portalSettings;
        }
    }
}
