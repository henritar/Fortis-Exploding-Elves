using Assets.Scripts.Runtime.ExplodingElves.Misc;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.UI.Spawners.Count
{
    public class SpawnerCountUIController : IInitializable, IDisposable
    {
        readonly SpawnerCountUIModel _model;
        readonly SpawnerCountUIView _view;
        readonly SignalBus _signalBus;

        public SpawnerCountUIController(SpawnerCountUIModel model, SpawnerCountUIView view, SignalBus signalBus)
        {
            _model = model;
            _view = view;
            _signalBus = signalBus;
        }


        public void Initialize()
        {
            HideSpawnCountUI();

            _model.BlackElfValueText.onEndEdit.AddListener((value) =>
            {
                var newValue = int.Parse(value);
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateBlackElfSignal()
                {
                    ElfName = "BlackElf",
                    SpawnCount = newValue
                });
            });

            _model.BlueElfValueText.onEndEdit.AddListener((value) =>
            {
                var newValue = int.Parse(value);
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateBlueElfSignal()
                {
                    ElfName = "BlueElf",
                    SpawnCount = newValue
                });
            });

            _model.RedElfValueText.onEndEdit.AddListener((value) =>
            {
                var newValue = int.Parse(value);
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateRedElfSignal()
                {
                    ElfName = "RedElf",
                    SpawnCount = newValue
                });
            });

            _model.WhiteElfValueText.onEndEdit.AddListener((value) =>
            {
                var newValue = int.Parse(value);
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateWhiteElfSignal()
                {
                    ElfName = "WhiteElf",
                    SpawnCount = newValue
                });
            });

            _model.CloseSpawnButton.onClick.AddListener(() => 
            {
                HideSpawnCountUI();
                _signalBus.Fire(new ReturnToMainUISignal());
            });

            _signalBus.Subscribe<AdjustSpawnCountSignal>(ShowSpawnCountUI);

        }

        public void Dispose()
        {
        }

        private void ShowSpawnCountUI(AdjustSpawnCountSignal signal)
        {
            _model.SpawnerCanvas.enabled = true;
        }

        private void HideSpawnCountUI()
        {
            _model.SpawnerCanvas.enabled = false;
        }

    }
}
