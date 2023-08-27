using Assets.Scripts.Runtime.ExplodingElves.Misc;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class ElfController : IInitializable, ITickable
    {
        protected readonly ElfModel _model;
        protected readonly ElfView _view;
        protected readonly SignalBus _signalBus;

        protected System.Random rng;

        public ElfController(ElfModel elfModel, ElfView elfView, SignalBus signalBus)
        {
            _model = elfModel;
            _view = elfView;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _model.ViewRigidbody.detectCollisions = false;

            rng = new System.Random();

            _view.tag = _model.ElfName;


            Observable.FromCoroutine(ActivateCollision).Subscribe();

            _view.gameObject.OnCollisionEnterAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.gameObject.CompareTag(_view.gameObject.tag))
                    {
                        _model.ViewRigidbody.detectCollisions = false;
                        _signalBus.Fire(new GenerativeCollisionEnterSignal() 
                            { 
                                CollisionHash = collision.gameObject.GetHashCode() + _view.gameObject.GetHashCode(), 
                                ColliderPrefabTag = _model.ElfName,
                                SpawnLocation = _view.transform.position
                            });
                        Observable.FromCoroutine(ActivateCollision).Subscribe();
                    }
                    else
                    {
                        _signalBus.Fire(new DestructiveCollisionSignal() 
                            { 
                                Collider = _view.gameObject.GetComponent<ElfView>(),
                            });
                    }
                });

            _view.gameObject.OnCollisionExitAsObservable().Subscribe(collision =>
            {
                _signalBus.Fire(new GenerativeCollisionExitSignal() 
                    { 
                        CollisionHash = collision.gameObject.GetHashCode() + _view.gameObject.GetHashCode() 
                    });
            });

        }

        public void Tick()
        {
            if (_model.NavAgent.velocity.magnitude < 1f)
            {
                SetNewTargetDestination();
            }
        }

        protected void SetNewTargetDestination()
        {
            int minValue = (int)(_model.FloorCenter - _model.FloorExtends);
            int maxValue = (int)(_model.FloorCenter + _model.FloorExtends);
            _model.TargetLocation = new Vector3(rng.Next(minValue, maxValue), _view.transform.position.y, rng.Next(minValue, maxValue));
            _model.NavAgent.destination = _model.TargetLocation;
        }

        protected IEnumerator ActivateCollision()
        {
            yield return new WaitForSeconds(0.8f);
            _model.ViewRigidbody.detectCollisions = true;
        }
    }
}