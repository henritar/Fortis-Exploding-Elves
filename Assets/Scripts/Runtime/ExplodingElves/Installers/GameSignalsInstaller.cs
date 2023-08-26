using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class GameSignalsInstaller : Installer<GameSignalsInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignalWithInterfaces<UpdateElfInstallSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<DestructiveCollisionSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<GenerativeCollisionEnterSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<GenerativeCollisionExitSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<UpdateBlackElfSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<UpdateBlueElfSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<UpdateRedElfSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<UpdateWhiteElfSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<UpdateElfSpawnRateUISignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<ReturnToMainUISignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<AdjustSpawnRateSignal>().OptionalSubscriber();
        }
    }
}