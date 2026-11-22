using UnityEngine;

namespace _Project.Develop.Runtime
{
    public class HoleField : MonoBehaviour
    {
        [SerializeField] private Transform[] _holes;
        
        public Transform[] Holes => _holes;
    }
}
