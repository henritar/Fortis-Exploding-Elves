using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals.VFX
{
    public class WhitePortalVFXView : GenericPortalVFXView
    {
        public class Factory : PlaceholderFactory<WhitePortalVFXView>
        {
        }

        public class PortalVFXPool : MonoPoolableMemoryPool<IMemoryPool, WhitePortalVFXView>
        {
        }
    }
}
