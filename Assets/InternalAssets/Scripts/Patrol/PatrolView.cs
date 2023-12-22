using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class PatrolView : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        public List<Transform> Points => _points;
    }
}