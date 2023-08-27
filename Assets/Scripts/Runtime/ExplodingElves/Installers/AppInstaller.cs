using Assets.Scripts.Runtime.ExplodingElves.Misc;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            GameSignalsInstaller.Install(Container);
        }

    }
}