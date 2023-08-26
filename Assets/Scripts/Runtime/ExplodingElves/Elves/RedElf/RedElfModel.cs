using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class RedElfModel : ElfModel
    {

        public RedElfModel(string elfName, Vector2Int initialPosition, NavMeshAgent navMeshAgent, Rigidbody viewRigidbody, Collider viewCollider)
            : base (elfName, initialPosition, navMeshAgent, viewRigidbody, viewCollider)
        {
        }
    }
}