using Assets.Scripts.Runtime.ExplodingElves.Elves;
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
}
