using _Project.Develop.Runtime.Meta.Features.Progress;
using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.MainMenu
{
    // Пока переход синхронный, сцена запускает себя сама: когда переход научится ждать её готовности, запускать будет он
    public sealed class MainMenuBootstrap : IStartable
    {
        private readonly PlayerProgressService _playerProgress;

        public MainMenuBootstrap(PlayerProgressService playerProgress)
        {
            _playerProgress = playerProgress;
        }

        public void Start()
        {
            Debug.Log($"Главное меню запущено, текущий уровень {_playerProgress.CurrentLevel}");
        }
    }
}
