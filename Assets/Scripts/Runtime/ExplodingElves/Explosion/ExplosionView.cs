using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Explosion
{
    public class ExplosionView : MonoBehaviour, IPoolable<IMemoryPool>
    {
        [SerializeField]
        float _lifeTime;

        [SerializeField]
        ParticleSystem _particleSystem;

        float _startTime;

        IMemoryPool _pool;

        public void Update()
        {
            if (Time.realtimeSinceStartup - _startTime > _lifeTime)
            {
                _pool.Despawn(this);
            }
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _particleSystem.Clear();
            _particleSystem.Play();

            _startTime = Time.realtimeSinceStartup;
            _pool = pool;
        }

        public class Factory : PlaceholderFactory<ExplosionView>
        {
        }

        public class ExplosionPool : MonoPoolableMemoryPool<IMemoryPool, ExplosionView>
        {
        }
    }
}
