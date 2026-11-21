using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Gameplay
{
    // Пока переход синхронный, сцена запускает себя сама: когда переход научится ждать её готовности, запускать будет он
    public sealed class GameplayBootstrap : IStartable
    {
        public void Start()
        {
            Debug.Log("Уровень запущен");
        }
    }
}
