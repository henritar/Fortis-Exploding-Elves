using Assets.Scripts.Runtime.ExplodingElves.Elves;
using UnityEngine;

namespace Assets.Scripts.Runtime.ExplodingElves.Misc
{
    public struct UpdateElfInstallSignal
    {
        public string ElfName { get; set; }
        public Vector2Int ElfStartLocation { get; set; }
    }

    public interface ICollisionSignal
    {
        public int CollisionHash { get; set; }
    }

    public struct DestructiveCollisionSignal : ICollisionSignal
    {
        public int CollisionHash { get; set; }
        public ElfView Collider { get; set; }
    }

    public struct GenerativeCollisionEnterSignal : ICollisionSignal
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

    public struct AdjustSpawnCountSignal
    {
    }

    public struct RestartGameSignal
    {
    }

    public interface IUpdateElfSpawnRate
    {
        public string ElfName { get; set; }
        public float SpawnRate { get; set; }
    }

    public interface IUpdateElfCountRate
    {
        public string ElfName { get; set; }
        public int SpawnCount { get; set; }
    }

    public struct UpdateBlackElfSignal : IUpdateElfSpawnRate, IUpdateElfCountRate
    {
        public string ElfName { get; set; }
        public float SpawnRate { get; set; }
        public int SpawnCount { get; set; }
    }
    public struct UpdateBlueElfSignal : IUpdateElfSpawnRate, IUpdateElfCountRate
    {
        public string ElfName { get; set; }
        public float SpawnRate { get; set; }
        public int SpawnCount { get; set; }
    }
    public struct UpdateRedElfSignal : IUpdateElfSpawnRate, IUpdateElfCountRate
    {
        public string ElfName { get; set; }
        public float SpawnRate { get; set; }
        public int SpawnCount { get; set; }
    }
    public struct UpdateWhiteElfSignal : IUpdateElfSpawnRate, IUpdateElfCountRate
    {
        public string ElfName { get; set; }
        public float SpawnRate { get; set; }
        public int SpawnCount { get; set; }
    }
}
