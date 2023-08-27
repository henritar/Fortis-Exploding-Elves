using Assets.Scripts.Runtime.ExplodingElves.Misc;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.ExplodingElves.UI.Spawners
{
    public class SpawnerUIController : IInitializable, IDisposable
    {
        readonly SpawnerUIModel _model;
        readonly SpawnerUIView _view;
        readonly SignalBus _signalBus;

        float MinSpawnRate = 0.25f;
        float SpawnDefinedRate = 0.25f;
        public SpawnerUIController(SpawnerUIModel model, SpawnerUIView view, SignalBus signalBus)
        {
            _model = model;
            _view = view;
            _signalBus = signalBus;
        }


        public void Initialize()
        {
            HideSpawnRateUI();

            _model.CloseSpawnButton.onClick.AddListener(() => 
            { 
                HideSpawnRateUI();
                _signalBus.Fire(new ReturnToMainUISignal());
            });

            _signalBus.Subscribe<AdjustSpawnRateSignal>(ShowSpawnRateUI);

            //Black Elf Buttons Listener
            _model.BlackElfDownButton.onClick.AddListener(() =>
            {
                var newValue = Mathf.Max(MinSpawnRate, float.Parse(_model.BlackElfValueText.text) - SpawnDefinedRate);
                _signalBus.AbstractFire(new UpdateBlackElfSignal()
                {
                    ElfName = "BlackElf",
                    SpawnRate = newValue
                });
                _model.BlackElfValueText.text = newValue.ToString();
            });

            _model.BlackElfUpButton.onClick.AddListener(() =>
            {
                var newValue = float.Parse(_model.BlackElfValueText.text) + SpawnDefinedRate;
                _signalBus.AbstractFire(new UpdateBlackElfSignal()
                {
                    ElfName = "BlackElf",
                    SpawnRate = newValue
                });
                _model.BlackElfValueText.text = newValue.ToString();
            });

            //Blue Elf Buttons Listener
            _model.BlueElfDownButton.onClick.AddListener(() =>
            {
                var newValue = Mathf.Max(MinSpawnRate, float.Parse(_model.BlueElfValueText.text) - SpawnDefinedRate);
                _signalBus.AbstractFire(new UpdateBlueElfSignal()
                {
                    ElfName = "BlueElf",
                    SpawnRate = newValue
                });
                _model.BlueElfValueText.text = newValue.ToString();
            });

            _model.BlueElfUpButton.onClick.AddListener(() =>
            {
                var newValue = float.Parse(_model.BlueElfValueText.text) + SpawnDefinedRate;
                _signalBus.AbstractFire(new UpdateBlueElfSignal()
                {
                    ElfName = "BlueElf",
                    SpawnRate = newValue
                });
                _model.BlueElfValueText.text = newValue.ToString();
            });

            //Red Elf Buttons Listener
            _model.RedElfDownButton.onClick.AddListener(() =>
            {
                var newValue = Mathf.Max(MinSpawnRate, float.Parse(_model.RedElfValueText.text) - SpawnDefinedRate);
                _signalBus.AbstractFire(new UpdateRedElfSignal()
                {
                    ElfName = "RedElf",
                    SpawnRate = newValue
                });
                _model.RedElfValueText.text = newValue.ToString();
            });

            _model.RedElfUpButton.onClick.AddListener(() =>
            {
                var newValue = float.Parse(_model.RedElfValueText.text) + SpawnDefinedRate;
                _signalBus.AbstractFire(new UpdateRedElfSignal()
                {
                    ElfName = "RedElf",
                    SpawnRate = newValue
                });
                _model.RedElfValueText.text = newValue.ToString();
            });

            //White Elf Buttons Listener
            _model.WhiteElfDownButton.onClick.AddListener(() =>
            {
                var newValue = Mathf.Max(MinSpawnRate, float.Parse(_model.WhiteElfValueText.text) - SpawnDefinedRate);
                _signalBus.AbstractFire(new UpdateWhiteElfSignal()
                {
                    ElfName = "WhiteElf",
                    SpawnRate = newValue
                });
                _model.WhiteElfValueText.text = newValue.ToString();
            });

            _model.WhiteElfUpButton.onClick.AddListener(() =>
            {
                var newValue = float.Parse(_model.WhiteElfValueText.text) + SpawnDefinedRate;
                _signalBus.AbstractFire(new UpdateWhiteElfSignal()
                {
                    ElfName = "WhiteElf",
                    SpawnRate = newValue
                });
                _model.WhiteElfValueText.text = newValue.ToString();
            });

        }

        public void Dispose()
        {
        }

        private void ShowSpawnRateUI(AdjustSpawnRateSignal signal)
        {
            _model.SpawnerCanvas.enabled = true;
        }

        private void HideSpawnRateUI()
        {
            _model.SpawnerCanvas.enabled = false;
        }

    }
}