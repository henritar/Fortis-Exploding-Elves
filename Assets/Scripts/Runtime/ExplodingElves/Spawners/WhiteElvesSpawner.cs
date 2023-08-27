using Assets.Scripts.Runtime.ExplodingElves.Elves;
using Assets.Scripts.Runtime.ExplodingElves.Installers;
using Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners
{
    public class WhiteElvesSpawner : GenericElvesSpawner
    {
        public WhiteElvesSpawner(WhiteElfView.Factory elfFactory, SpawnPortalView.Factory whitePortalFactory, SignalBus signalBus,
            MainSceneInstaller.ElfSettings elvesSettings, MainSceneInstaller.PortalSettings portalSettings) 
            : base (signalBus, elvesSettings)
        {
            _elfFactory = elfFactory;
            _portalFactory = whitePortalFactory;
            _portalSettings = portalSettings;
        }
    }
}
