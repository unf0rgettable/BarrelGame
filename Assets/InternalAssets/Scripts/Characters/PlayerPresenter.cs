using System;
using InternalAssets.Scripts.Joysticks;
using InternalAssets.Scripts.Triggers;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Scripts.Player
{
    public class PlayerPresenter : ITickable
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly JoystickInputSystem _joystickInputSystem;
        private readonly PlayerModel _playerModel;
        private readonly FinishService _finishService;
        private readonly Animator _animator;
        private readonly Animator _barrelAnimator;
        private readonly Collider _playerCollider;
        private readonly BulletTrigger _bulletTrigger;
        
        private float _speed = 0;
        private bool _canWalk => _animator.GetBehaviour<PlayerStateMachine>().CanWalk;

        public PlayerPresenter(JoystickInputSystem joystickInputSystem,
            PlayerModel playerModel,
            Player player,
            FinishService finishService)
        {
            _navMeshAgent = player.NavMeshAgent;
            _joystickInputSystem = joystickInputSystem;
            _playerModel = playerModel;
            _finishService = finishService;
            _animator = player.Animator;
            _barrelAnimator = player.BarrelAnimator;
            _playerCollider = player.PlayerCollider.GetComponent<Collider>();
            _bulletTrigger = player.BulletTrigger;
            _bulletTrigger.OnEnter += BulletTriggerOnOnEnter;
            player.FinishTrigger.OnEnter += FinishServiceOnFinish;
        }

        private void FinishServiceOnFinish(FinishCollider obj)
        {
            _playerCollider.gameObject.SetActive(false);
            _bulletTrigger.gameObject.SetActive(false);
            
            _joystickInputSystem.SetCanMove(false);
            _animator.SetTrigger("Finish");
            _barrelAnimator.SetTrigger("Dance");
            _animator.GetBehaviour<DanceSatateMachine>().OnDance += () =>
            {
                _finishService.OnFinish?.Invoke();
            };
        }

        private void BulletTriggerOnOnEnter(BulletCollider obj)
        {
            _playerCollider.enabled = false;
            _joystickInputSystem.SetCanMove(false);
            _finishService.OnDie?.Invoke();
        }
        
        public void Tick()
        {
            var inputMagnitude = _joystickInputSystem.Direction.magnitude;
            
            if (inputMagnitude > 0 && _canWalk)
            {
                Vector3 currentPosition = _navMeshAgent.transform.position;
                Vector3 targetPosition = currentPosition + _joystickInputSystem.Direction;
                Vector3 forward = targetPosition - currentPosition;
                Vector3 dir = forward.normalized;
                
                var velocity = forward * _playerModel.Speed;
                _speed = velocity.magnitude;
                _animator.SetFloat("Speed", _speed);
                _barrelAnimator.SetFloat("Speed", _speed);
                _navMeshAgent.Move(velocity * Time.deltaTime);
                _playerCollider.gameObject.SetActive(true);
                _animator.transform.forward = dir;
            }
            else
            {
                _speed = Mathf.Lerp(_speed, 0, Time.deltaTime * 5);
                _playerCollider.gameObject.SetActive(false);
                _animator.SetFloat("Speed", _speed);
                _barrelAnimator.SetFloat("Speed", _speed);
            }
        }
    }
}