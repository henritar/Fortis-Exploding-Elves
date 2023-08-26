using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public abstract class ElfView : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        IMemoryPool _pool;

        public void Dispose()
        {
            Debug.Log("Dispose" + gameObject.name + " index: " + gameObject.transform.GetSiblingIndex());
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _pool = null; 
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }
        
    }

}