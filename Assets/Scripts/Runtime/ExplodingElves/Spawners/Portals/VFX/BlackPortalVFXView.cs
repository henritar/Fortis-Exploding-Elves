using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals.VFX
{
    public class BlackPortalVFXView : GenericPortalVFXView
    {
        public class Factory : PlaceholderFactory<BlackPortalVFXView>
        {
        }

        public class PortalVFXPool : MonoPoolableMemoryPool<IMemoryPool, BlackPortalVFXView>
        {
        }

    }
}
