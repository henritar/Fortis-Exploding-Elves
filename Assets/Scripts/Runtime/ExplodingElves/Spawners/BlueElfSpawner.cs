using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class BlueElvesSpawner : GenericElvesSpawner
    {
        public BlueElvesSpawner(BlueElfView.Factory elfFactory, SpawnPortalView.Factory bluePortalFactory, SignalBus signalBus,
            MainSceneInstaller.ElfSettings elvesSettings, MainSceneInstaller.PortalSettings portalSettings)
            : base(signalBus, elvesSettings)
        {
            _elfFactory = elfFactory;
            _portalFactory = bluePortalFactory;
            _portalSettings = portalSettings;
        }
    }
}
