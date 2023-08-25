using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameSignalsInstaller.Install(Container);
        }

    }
}