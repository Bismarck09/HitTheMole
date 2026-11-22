using _Project.Develop.Runtime.Infrastructure.ConfigsService;

namespace _Project.Develop.Runtime.Meta.Features.Progress
{
    public sealed class PlayerProgressService
    {
        private readonly ConfigsProviderService _configsProvider;
        private int _highestUnlockedLevel = 1;

        public PlayerProgressService(ConfigsProviderService configsProvider)
        {
            _configsProvider = configsProvider;
        }

        public int LevelCount => _configsProvider.GetConfig<MapDataConfig>().LevelCount;

        public bool IsUnlocked(int level) => level >= 1 && level <= _highestUnlockedLevel && level <= LevelCount;

        public void CompleteLevel(int completedLevel)
        {
            if (completedLevel == _highestUnlockedLevel && completedLevel < LevelCount)
                _highestUnlockedLevel++;
        }
    }
}
