using InternalAssets.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerSettings _playerSettings;

        public PlayerSettings PlayerSettings => _playerSettings;
        public Camera Camera => _camera;
        public Animator Animator => _animator;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
    }
}