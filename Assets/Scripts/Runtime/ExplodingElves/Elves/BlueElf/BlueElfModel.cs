using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class BlueElfModel : ElfModel
    {

        public BlueElfModel(string elfName, Vector2Int initialPosition, NavMeshAgent navMeshAgent, Rigidbody viewRigidbody, Collider viewCollider)
            : base (elfName, initialPosition, navMeshAgent, viewRigidbody, viewCollider)
        {
        }
    }
}