using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.MainMenu
{
    public class MainMenuLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainMenuBootstrap>(Lifetime.Scoped);
            builder.RegisterEntryPoint<MainMenuInput>(Lifetime.Scoped);
        }
    }
}
