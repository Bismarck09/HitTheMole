using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Gameplay
{
    internal sealed class GameplayBootstrap : IStartable
    {
        private readonly GameFieldInitializer _gameFieldInitializer;
        private readonly GameplaySessionController _session;

        public GameplayBootstrap(GameFieldInitializer gameFieldInitializer, GameplaySessionController session)
        {
            _gameFieldInitializer = gameFieldInitializer;
            _session = session;
        }

        public void Start()
        {
            _gameFieldInitializer.Initialize();
            _session.Start();
        }
    }
}
