using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class WhiteElfView : ElfView
    {
        public class Factory : PlaceholderFactory<WhiteElfView> 
        {
        }
        public class WhiteElfPool : MonoPoolableMemoryPool<IMemoryPool, WhiteElfView>
        {
        }
    }
}