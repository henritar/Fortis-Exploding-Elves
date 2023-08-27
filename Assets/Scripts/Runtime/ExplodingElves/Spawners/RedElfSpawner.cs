using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class RedElvesSpawner : GenericElvesSpawner
    {
        public RedElvesSpawner(RedElfView.Factory elfFactory, SpawnPortalView.Factory redPortalFactory, SignalBus signalBus,
            MainSceneInstaller.ElfSettings elvesSettings, MainSceneInstaller.PortalSettings portalSettings)
            : base(signalBus, elvesSettings)
        {
            _elfFactory = elfFactory;
            _portalFactory = redPortalFactory;
            _portalSettings = portalSettings;
        }
    }
}
