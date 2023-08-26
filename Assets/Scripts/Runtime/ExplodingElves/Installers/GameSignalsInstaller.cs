using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class GameSignalsInstaller : Installer<GameSignalsInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignalWithInterfaces<UpdateElfInstall>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<DestructiveCollisionSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<GenerativeCollisionEnterSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<GenerativeCollisionExitSignal>().OptionalSubscriber();
        }
    }
}