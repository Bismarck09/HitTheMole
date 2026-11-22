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
            builder.Register<InputService>(Lifetime.Scoped);
            
            builder.RegisterEntryPoint<GameplayBootstrap>();
            builder.RegisterEntryPoint<GameplayDebugInput>();
            builder.RegisterEntryPoint<GameFieldInitializer>();
            builder.RegisterEntryPoint<MoleGameService>();
        }
    }
}
