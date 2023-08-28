using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals.VFX
{
    public class BluePortalVFXView : GenericPortalVFXView
    {
        public class Factory : PlaceholderFactory<BluePortalVFXView>
        {
        }

        public class PortalVFXPool : MonoPoolableMemoryPool<IMemoryPool, BluePortalVFXView>
        {
        }

    }
}
