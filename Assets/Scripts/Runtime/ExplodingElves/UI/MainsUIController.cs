using Assets.Scripts.Runtime.ExplodingElves.Misc;
using UnityEngine;
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

            _model.SettingsButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new AdjustSpawnRateSignal());
                _model.SettingsButton.enabled = false;
            });
        }

        private void ResetMainUI(ReturnToMainUISignal signal)
        {
            _model.SettingsButton.enabled = true;
        }
    }
}
