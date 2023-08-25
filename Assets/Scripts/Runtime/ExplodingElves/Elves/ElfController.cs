using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.Elves
{
    public class ElfController : IInitializable, ITickable
    {
        protected readonly ElfModel _model;
        protected readonly ElfView _view;

        protected System.Random rng;

        public ElfController(ElfModel elfModel, ElfView elfView)
        {
            _model = elfModel;
            _view = elfView;
        }

        public void Initialize()
        {
            _view.transform.position = new Vector3(_model.XPosition, _view.transform.position.y, _model.ZPosition);
            rng = new System.Random();
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
    }
}