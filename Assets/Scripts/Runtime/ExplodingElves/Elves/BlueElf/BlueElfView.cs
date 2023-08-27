using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class BlueElfView : ElfView
    {
        public class Factory : PlaceholderFactory<BlueElfView> 
        {
        }
        public class BlueElfPool : MonoPoolableMemoryPool<IMemoryPool, BlueElfView>
        {
        }
    }
}