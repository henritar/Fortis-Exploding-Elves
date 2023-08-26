using Assets.Scripts.Runtime.ExplodingElves.Elves;
using UnityEngine;

namespace Assets.Scripts.Runtime.ExplodingElves.Misc
{
    public struct UpdateElfInstallSignal
    {
        public string ElfName { get; set; }
        public Vector2Int ElfStartLocation { get; set; }
    }

    public struct DestructiveCollisionSignal
    {
        public ElfView Collider { get; set; }
    }

    public struct GenerativeCollisionEnterSignal
    {
        public int CollisionHash { get; set; }
        public string ColliderPrefabTag { get; set; }
        public Vector3 SpawnLocation { get; set; }
    }

    public struct GenerativeCollisionExitSignal
    {
        public int CollisionHash { get; set; }
    }

    public struct ReturnToMainUISignal
    {
    }

    public struct AdjustSpawnRateSignal
    {
    }

    public interface IUpdateElfSpawnRate
    {
        public string ElfName { get; set; }
        public int SpawnRate { get; set; }
    }

    public struct UpdateBlackElfSignal : IUpdateElfSpawnRate
    {
        public string ElfName { get; set; }
        public int SpawnRate { get; set; }
    }
    public struct UpdateBlueElfSignal : IUpdateElfSpawnRate
    {
        public string ElfName { get; set; }
        public int SpawnRate { get; set; }
    }
    public struct UpdateRedElfSignal : IUpdateElfSpawnRate
    {
        public string ElfName { get; set; }
        public int SpawnRate { get; set; }
    }
    public struct UpdateWhiteElfSignal : IUpdateElfSpawnRate
    {
        public string ElfName { get; set; }
        public int SpawnRate { get; set; }
    }

    public struct UpdateElfSpawnRateUISignal
    {
        public string BlackElfSpawnRateText { get; set; }
        public string BlueElfSpawnRateText { get; set; }
        public string RedElfSpawnRateText { get; set; }
        public string WhiteElfSpawnRateText { get; set; }
    }
}
