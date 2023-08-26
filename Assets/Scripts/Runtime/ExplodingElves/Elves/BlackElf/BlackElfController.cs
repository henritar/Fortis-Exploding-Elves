using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class BlackElfController : ElfController
    {
        public BlackElfController(BlackElfModel elfModel, BlackElfView elfView, SignalBus signalBus) 
            : base(elfModel, elfView, signalBus) 
        {
        }
    }
}