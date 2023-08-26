using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class WhiteElfController : ElfController
    {

        public WhiteElfController(WhiteElfModel elfModel, WhiteElfView elfView, SignalBus signalBus)
            : base (elfModel, elfView, signalBus)
        {
        }

    }
}