using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Meta.Features.Progress;
using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.MainMenu
{
    internal sealed class MainMenuInput : ITickable
    {
        private readonly GameNavigation _gameNavigation;
        private readonly PlayerProgressService _playerProgress;
        private readonly InputService _inputService;

        private bool _isLeaving;

        public MainMenuInput(GameNavigation gameNavigation, PlayerProgressService playerProgress, InputService inputService)
        {
            _gameNavigation = gameNavigation;
            _playerProgress = playerProgress;
            _inputService = inputService;
        }

        public void Tick()
        {
            if (_isLeaving)
                return;

            for (int level = 1; level <= _playerProgress.LevelCount; level++)
            {
                if (_inputService.IsNumberPressed(level) == false)
                    continue;

                if (_playerProgress.IsUnlocked(level))
                {
                    _isLeaving = true;
                    _gameNavigation.OpenGameplay(level);
                }
                else
                {
                    Debug.Log($"Уровень {level} закрыт.");
                }

                return;
            }
        }
    }
}
