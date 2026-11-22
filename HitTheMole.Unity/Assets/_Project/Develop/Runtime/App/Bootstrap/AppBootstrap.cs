using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.ConfigsService;
using _Project.Develop.Runtime.Meta.Features.Economy;
using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Bootstrap
{
    public sealed class AppBootstrap : IStartable
    {
        private const int TARGET_FRAME_RATE = 60;

        private readonly ConfigsProviderService _configsProviderService;
        private readonly GameNavigation _gameNavigation;
        private readonly WalletService _wallet;

        public AppBootstrap(ConfigsProviderService configsProviderService, GameNavigation gameNavigation, WalletService wallet)
        {
            _configsProviderService = configsProviderService;
            _gameNavigation = gameNavigation;
            _wallet = wallet;
        }

        public void Start()
        {
            SetupApp();

            _configsProviderService.Load();

            int startingGold = _configsProviderService.GetConfig<MapDataConfig>().StartingGold;
            if (startingGold > 0)
                _wallet.Add(CurrencyId.Gold, startingGold);

            _gameNavigation.OpenMainMenu();
        }

        private void SetupApp()
        {
            Application.targetFrameRate = TARGET_FRAME_RATE;
            QualitySettings.vSyncCount = 0;
        }
    }
}
