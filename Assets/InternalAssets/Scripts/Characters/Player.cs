using InternalAssets.Scripts.Triggers;
using InternalAssets.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Animator _barrelAnimator;
        [SerializeField] private PlayerCollider _playerCollider;
        [SerializeField] private FinishTrigger _finishTrigger;
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private BulletTrigger _bulletTrigger;

        public BulletTrigger BulletTrigger => _bulletTrigger;
        public FinishTrigger FinishTrigger => _finishTrigger;
        public Animator BarrelAnimator => _barrelAnimator;
        public PlayerSettings PlayerSettings => _playerSettings;
        public Animator Animator => _animator;
        public PlayerCollider PlayerCollider => _playerCollider;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
    }
}