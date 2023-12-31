using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class ElfModel
    {
        public string ElfName;
        public int XPosition;
        public int ZPosition;

        [Inject(Id = "floorCenter")]
        public float FloorCenter;
        [Inject(Id = "floorExtends")]
        public float FloorExtends;

        public Vector3 TargetLocation;

        public NavMeshAgent NavAgent;

        public Rigidbody ViewRigidbody;
        public Collider ViewCollider;

        public ElfModel(string elfName, Vector2Int initialPosition, NavMeshAgent navMeshAgent, Rigidbody viewRigidbody, Collider viewCollider)
        {
            ElfName = elfName;
            XPosition = initialPosition.x;
            ZPosition = initialPosition.y;
            NavAgent = navMeshAgent;
            ViewRigidbody = viewRigidbody;
            ViewCollider = viewCollider;
        }
    }
}