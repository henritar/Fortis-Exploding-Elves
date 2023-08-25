using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    [CreateAssetMenu(fileName = "AppSettingsInstaller", menuName = "Installers/AppSettingsInstaller")]
    public class AppSettingsInstaller : ScriptableObjectInstaller<AppSettingsInstaller>
    {
        [SerializeField] private MainSceneInstaller.ElfSettings[] ElvesSettings;
        [SerializeField] private MainSceneInstaller.FloorSetting FloorSettings;
        public override void InstallBindings()
        {
            Container.BindInstance(ElvesSettings).WithId("elves").IfNotBound();
            Container.BindInstance(FloorSettings).IfNotBound();
        }
    }
}