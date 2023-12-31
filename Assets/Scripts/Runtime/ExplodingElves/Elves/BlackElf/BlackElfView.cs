using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class BlackElfView : ElfView
    {
        public class Factory : PlaceholderFactory<BlackElfView> 
        {
        }
        public class BlackElfPool : MonoPoolableMemoryPool<IMemoryPool, BlackElfView>
        {
        }
    }
}