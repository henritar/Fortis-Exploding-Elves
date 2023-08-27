using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Spawners.Portals
{
    public class SpawnPortalView : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, SpawnPortalView>
        {
        }
    }
}
