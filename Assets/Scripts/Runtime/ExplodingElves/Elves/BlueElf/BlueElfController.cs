using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class BlueElfController : ElfController    {
        public BlueElfController(BlueElfModel elfModel, BlueElfView elfView, SignalBus signalBus) 
            : base (elfModel, elfView, signalBus)
        {
        }

    }
}