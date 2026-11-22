using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameFieldFactory>(Lifetime.Scoped);
            builder.Register<MoleHoleRepository>(Lifetime.Scoped);
            builder.Register<GameFieldInitializer>(Lifetime.Scoped);
            builder.Register<LevelData>(Lifetime.Scoped);

            builder.RegisterEntryPoint<GameplayBootstrap>(Lifetime.Scoped);
            builder.RegisterEntryPoint<GameplaySessionController>(Lifetime.Scoped).AsSelf();
            builder.RegisterEntryPoint<MoleGameService>(Lifetime.Scoped).AsSelf();
        }
    }
}
