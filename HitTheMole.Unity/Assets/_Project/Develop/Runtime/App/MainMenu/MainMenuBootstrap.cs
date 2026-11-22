using System.Text;
using _Project.Develop.Runtime.Meta.Features.Economy;
using _Project.Develop.Runtime.Meta.Features.Progress;
using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.MainMenu
{
    public sealed class MainMenuBootstrap : IStartable
    {
        private readonly PlayerProgressService _playerProgress;
        private readonly WalletService _wallet;

        public MainMenuBootstrap(PlayerProgressService playerProgress, WalletService wallet)
        {
            _playerProgress = playerProgress;
            _wallet = wallet;
        }

        public void Start()
        {
            StringBuilder menu = new();
            menu.AppendLine("Бей крота");
            menu.AppendLine($"Золото: {_wallet.Get(CurrencyId.Gold)}");

            for (int level = 1; level <= _playerProgress.LevelCount; level++)
            {
                string status = _playerProgress.IsUnlocked(level) ? "открыт" : "закрыт";
                menu.AppendLine($"{level}. Уровень {level} — {status}");
            }

            menu.Append("Нажмите цифру для выбора уровня.");
            Debug.Log(menu.ToString());
        }
    }
}
