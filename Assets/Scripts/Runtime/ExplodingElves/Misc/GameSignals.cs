using UnityEngine;

namespace Assets.Scripts.Runtime.ExplodingElves.Misc
{
    public interface IUpdateSpawnRateSignal
    {
        public float NewSpawnRate { get; set; }
    }

    public struct UpdateElfInstall
    {
        public string ElfName { get; set; }
        public Vector2Int ElfStartLocation { get; set; }
    }
}
