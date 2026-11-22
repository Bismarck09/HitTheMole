using System;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.ConfigsService;
using _Project.Develop.Runtime.Meta.Features.Economy;
using _Project.Develop.Runtime.Meta.Features.Progress;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Gameplay
{
    internal sealed class GameplaySessionController : ITickable, IDisposable
    {
        private readonly GameNavigation _gameNavigation;
        private readonly ConfigsProviderService _configsProvider;
        private readonly PlayerProgressService _playerProgress;
        private readonly WalletService _wallet;
        private readonly InputService _inputService;
        private readonly MoleGameService _moleGameService;
        private readonly LevelData _levelData;

        private int _level;
        private bool _isLeaving;

        public GameplaySessionController(GameNavigation gameNavigation, ConfigsProviderService configsProvider,
            PlayerProgressService playerProgress, WalletService wallet, InputService inputService,
            MoleGameService moleGameService, LevelData levelData)
        {
            _gameNavigation = gameNavigation;
            _configsProvider = configsProvider;
            _playerProgress = playerProgress;
            _wallet = wallet;
            _inputService = inputService;
            _moleGameService = moleGameService;
            _levelData = levelData;
        }

        public void Start()
        {
            _level = _gameNavigation.GameplayLevel;
            LevelConditions conditions = _configsProvider.GetConfig<MapDataConfig>().GetLevel(_level);

            _levelData.OnFinished += Finish;
            _levelData.Initialize(conditions);
            _moleGameService.Start(conditions);

            Debug.Log($"Уровень {_level}. Цель — {conditions.CountPointsRequiredToWin}, жизней — {conditions.Health}.");
        }

        public void Tick()
        {
            if (_isLeaving || _levelData.IsFinished == false)
                return;

            if (_inputService.IsPressed(Key.Space))
            {
                _isLeaving = true;

                if (_levelData.IsWon)
                    _gameNavigation.OpenMainMenu();
                else
                    _gameNavigation.OpenGameplay(_level);
            }
            else if (_levelData.IsWon == false && _inputService.IsPressed(Key.Escape))
            {
                _isLeaving = true;
                _gameNavigation.OpenMainMenu();
            }
        }

        public void Dispose()
        {
            _levelData.OnFinished -= Finish;
        }

        private void Finish()
        {
            _moleGameService.Stop();

            if (_levelData.IsWon)
            {
                if (_levelData.AccumulatedGold > 0)
                    _wallet.Add(CurrencyId.Gold, _levelData.AccumulatedGold);

                _playerProgress.CompleteLevel(_level);

                Debug.Log($"Победа! Получено золота: {_levelData.AccumulatedGold}. Space — главное меню.");
            }
            else
            {
                Debug.Log("Поражение! Золото за забег потеряно. Space — повторить уровень, Escape — главное меню.");
            }
        }
    }
}
