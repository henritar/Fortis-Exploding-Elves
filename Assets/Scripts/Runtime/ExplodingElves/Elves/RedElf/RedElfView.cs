using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class RedElfView : ElfView
    {
        public class Factory : PlaceholderFactory<RedElfView> 
        {
        }
        public class RedElfPool : MonoPoolableMemoryPool<IMemoryPool, RedElfView>
        {
        }
    }
}