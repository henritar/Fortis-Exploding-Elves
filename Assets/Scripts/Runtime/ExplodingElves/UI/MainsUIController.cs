using Assets.Scripts.Runtime.ExplodingElves.Misc;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.UI
{
    public class MainsUIController : IInitializable
    {
        readonly MainUIModel _model;
        readonly MainUIView _view;
        readonly SignalBus _signalBus;

        public MainsUIController(MainUIModel model, MainUIView view, SignalBus signalBus)
        {
            _model = model;
            _view = view;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ReturnToMainUISignal>(ResetMainUI);

            _model.SpawnRateSettingsButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new AdjustSpawnRateSignal());
                _model.MainUICanvas.enabled = false;
            });

            _model.SpawnCountSettingsButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new AdjustSpawnCountSignal());
                _model.MainUICanvas.enabled = false;
            });

            _model.RestartButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new RestartGameSignal());
            });
        }

        private void ResetMainUI(ReturnToMainUISignal signal)
        {
            _model.MainUICanvas.enabled = true;
        }
    }
}
