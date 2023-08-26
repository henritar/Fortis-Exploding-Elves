using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class RedElfController : ElfController
    {

        public RedElfController(RedElfModel elfModel, RedElfView elfView, SignalBus signalBus)
            : base(elfModel, elfView, signalBus)
        {
        }

    }
}