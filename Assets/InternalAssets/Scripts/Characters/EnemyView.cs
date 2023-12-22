using InternalAssets.Scripts.Triggers;
using InternalAssets.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Scripts.Player
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private EnemySettings _enemySettings;
        [SerializeField] private PlayerTrigger _playerTrigger;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private Transform _visablePoint;

        public Transform VisablePoint => _visablePoint;
        public Transform ShotPoint => _shotPoint;
        public PlayerTrigger PlayerTrigger => _playerTrigger;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public EnemySettings EnemySettings => _enemySettings;
        public Animator Animator => _animator;
    }
}