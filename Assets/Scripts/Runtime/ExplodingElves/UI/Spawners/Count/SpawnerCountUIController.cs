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

        int MinCount = 10;

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
                int newValue;
                int.TryParse(value, out newValue);
                newValue = newValue != default ? newValue : MinCount;
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateBlackElfSignal()
                {
                    ElfName = "BlackElf",
                    SpawnCount = newValue
                });
                _model.BlackElfValueText.text = newValue.ToString();
            });

            _model.BlueElfValueText.onEndEdit.AddListener((value) =>
            {
                int newValue;
                int.TryParse(value, out newValue);
                newValue = newValue != default ? newValue : MinCount;
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateBlueElfSignal()
                {
                    ElfName = "BlueElf",
                    SpawnCount = newValue 
                });
                _model.BlueElfValueText.text = newValue.ToString();
            });

            _model.RedElfValueText.onEndEdit.AddListener((value) =>
            {
                int newValue;
                int.TryParse(value, out newValue);
                newValue = newValue != default ? newValue : MinCount;
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateRedElfSignal()
                {
                    ElfName = "RedElf",
                    SpawnCount = newValue
                });
                _model.RedElfValueText.text = newValue.ToString();
            });

            _model.WhiteElfValueText.onEndEdit.AddListener((value) =>
            {
                int newValue;
                int.TryParse(value, out newValue);
                newValue = newValue != default ? newValue : MinCount;
                _signalBus.AbstractFire<IUpdateElfCountRate>(new UpdateWhiteElfSignal()
                {
                    ElfName = "WhiteElf",
                    SpawnCount = newValue
                });
                _model.WhiteElfValueText.text = newValue.ToString();
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
            _model.BlackElfValueText.onEndEdit.RemoveAllListeners();
            _model.BlueElfValueText.onEndEdit.RemoveAllListeners();
            _model.RedElfValueText.onEndEdit.RemoveAllListeners();
            _model.WhiteElfValueText.onEndEdit.RemoveAllListeners();
            _model.CloseSpawnButton.onClick.RemoveAllListeners();
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
