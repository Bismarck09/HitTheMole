using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Gameplay
{
    public sealed class GameplayBootstrap : IStartable
    {
        public void Start()
        {
            Debug.Log("Уровень запущен");
        }
    }
}
