using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime
{
    [CreateAssetMenu(fileName = "MapDataConfig", menuName = "Configs/MapDataConfig")]
    public class MapDataConfig : ScriptableObject
    {
        [SerializeField] private HoleField _holeField;
        [SerializeField] private GameObject _molePrefab;
        [SerializeField] private float _popUpDuration;
        [SerializeField] private float _popUpInterval;
        [SerializeField] private int _health;
        [SerializeField] private int _countPointsRequiredToWin;
        [SerializeField] private int _goldPerClick;
        
        public HoleField Field => _holeField;
        public GameObject MolePrefab => _molePrefab;
        public float PopUpDuration => _popUpDuration;
        public float PopUpInterval => _popUpInterval;
        public int Health => _health;
        public int CountPointsRequiredToWin => _countPointsRequiredToWin;
        public int GoldPerClick => _goldPerClick;
    }
}
