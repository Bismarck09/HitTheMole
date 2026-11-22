using System;
using UnityEngine;

namespace _Project.Develop.Runtime
{
    [CreateAssetMenu(fileName = "MapDataConfig", menuName = "Configs/MapDataConfig")]
    public class MapDataConfig : ScriptableObject
    {
        [SerializeField] private HoleField _holeField;
        [SerializeField] private MoleData _molePrefab;
        [SerializeField, Min(0)] private int _startingGold;
        [SerializeField] private LevelConditions[] _levels = Array.Empty<LevelConditions>();

        public HoleField Field => _holeField;
        public MoleData MolePrefab => _molePrefab;
        public int StartingGold => _startingGold;
        public int LevelCount => Mathf.Min(_levels.Length, InputService.NumberKeyCount);

        internal LevelConditions GetLevel(int level) => _levels[level - 1];
    }
}
