using UnityEngine;
using VContainer;
using VContainer.Unity;

internal sealed class GameFieldFactory
{
    private readonly IObjectResolver _resolver;

    public GameFieldFactory(IObjectResolver resolver)
    {
        _resolver = resolver;
    }

    public T Create<T>(T prefab, Vector3 position, Quaternion rotation) where T : Component
    {
        return _resolver.Instantiate(prefab, position, rotation);
    }
}
