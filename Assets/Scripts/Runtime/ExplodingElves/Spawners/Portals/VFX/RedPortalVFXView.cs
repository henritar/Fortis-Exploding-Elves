using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals.VFX
{
    public class RedPortalVFXView : GenericPortalVFXView
    {
        public class Factory : PlaceholderFactory<RedPortalVFXView>
        {
        }

        public class PortalVFXPool : MonoPoolableMemoryPool<IMemoryPool, RedPortalVFXView>
        {
        }

    }
}
