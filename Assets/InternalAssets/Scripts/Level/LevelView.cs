using System.Collections.Generic;
using InternalAssets.Scripts.Player;
using InternalAssets.Scripts.Triggers;
using UnityEngine;

namespace InternalAssets.Scripts.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private List<Enemy> _enemy;
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;
        public Transform SpawnPoint => _spawnPoint;
        public List<Enemy> Enemy => _enemy;
    }
}