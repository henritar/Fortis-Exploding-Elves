using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Installers
{
    [CreateAssetMenu(fileName = "AppSettingsInstaller", menuName = "Installers/AppSettingsInstaller")]
    public class AppSettingsInstaller : ScriptableObjectInstaller<AppSettingsInstaller>
    {
        [SerializeField] private MainSceneInstaller.ElfSettings[] ElvesSettings;
        [SerializeField] private MainSceneInstaller.PortalSettings[] PortalSettings;
        [SerializeField] private MainSceneInstaller.FloorSetting FloorSettings;
        public override void InstallBindings()
        {
            Container.BindInstance(ElvesSettings).WithId("elves").IfNotBound();
            Container.BindInstance(FloorSettings).IfNotBound();
            Container.BindInstance(PortalSettings[0]).WithId("blackSpawnPortal").IfNotBound();
            Container.BindInstance(PortalSettings[1]).WithId("blueSpawnPortal").IfNotBound();
            Container.BindInstance(PortalSettings[2]).WithId("redSpawnPortal").IfNotBound();
            Container.BindInstance(PortalSettings[3]).WithId("whiteSpawnPortal").IfNotBound();
        }
    }
}