using System;
using InternalAssets.Scripts.Bullets;
using InternalAssets.Scripts.Detect;
using InternalAssets.Scripts.Enums;
using InternalAssets.Scripts.Triggers;
using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class EnemyPresenter
    {
        private readonly EnemyView _enemyView;
        private readonly PatrolService _patrolService;
        private readonly EnemyModel _enemyModel;
        private readonly BulletSystem _bulletSystem;
        private readonly DetectSystem _detectSystem;
        private EnemyState _state = EnemyState.Walk;
        public EnemyPresenter(EnemyView enemyView,
            PatrolService patrolService,
            EnemyModel enemyModel,
            BulletSystem bulletSystem,
            DetectSystem detectSystem)
        {
            _enemyView = enemyView;
            _patrolService = patrolService;
            _enemyModel = enemyModel;
            _bulletSystem = bulletSystem;
            _detectSystem = detectSystem;

            _enemyView.transform.position = _patrolService.GetNextPoint().position;
            _enemyView.NavMeshAgent.speed = _enemyModel.Speed;
            
            enemyView.PlayerTrigger.transform.localScale = Vector3.one * _enemyModel.AttackRangeRadius;
            
            //enemyView..OnEnter += PlayerTriggerOnEnter;
            enemyView.Animator.GetBehaviour<EnemyAimStateMachine>().OnAim += OnAim;
        }

        private void OnAim()
        {
            _state = EnemyState.Shot;
        }

        private void PlayerTriggerOnEnter()
        {
            _state = EnemyState.Aim;
            _enemyView.Animator.SetBool("Shot", true);
            _enemyView.Animator.SetTrigger("Aim");
        }

        public void Tick()
        {
            switch (_state)
            {
                case EnemyState.Walk:
                    Walk();
                    break;
                case EnemyState.Aim:
                    Aim();
                    break;
                case EnemyState.Shot:
                    Shot();
                    break;
            }
        }

        private void Walk()
        {
            _enemyView.NavMeshAgent.enabled = true;
            
            _enemyView.NavMeshAgent.SetDestination(Vector3.Distance(_patrolService.CurrentPatrolPoint.position,
                _enemyView.NavMeshAgent.transform.position) < 0.1f
                ? _patrolService.GetNextPoint().position
                : _patrolService.CurrentPatrolPoint.position);
            
            _enemyView.Animator.SetFloat("Speed", _enemyView.NavMeshAgent.velocity.magnitude);

            //Debug.DrawRay(_enemyView.transform.position, (_enemyView.VisablePoint.position - _enemyView.transform.position));
            
            _detectSystem.FindObject(_enemyView, _enemyModel.AttackDegree, _enemyModel.AttackRangeRadius);
            if (_detectSystem.PlayerCollider != null)
            {
                PlayerTriggerOnEnter();
            }
        }

        private void Aim()
        {
            _detectSystem.FindObject(_enemyView, _enemyModel.AttackDegree, _enemyModel.AttackRangeRadius);
            if (_detectSystem.PlayerCollider == null)
            {
                _state = EnemyState.Walk;
                _enemyView.Animator.SetBool("Shot", false);
                
                return;
            }

            _enemyView.NavMeshAgent.ResetPath();
            Vector3 forward = _detectSystem.PlayerCollider.transform.position - _enemyView.NavMeshAgent.transform.position;
            _enemyView.NavMeshAgent.transform.forward = forward;
        }
        
        private void Shot()
        {
            _state = EnemyState.Aim;
            
            _detectSystem.FindObject(_enemyView, _enemyModel.AttackDegree, _enemyModel.AttackRangeRadius);
            if (_detectSystem.PlayerCollider != null)
            {
                _bulletSystem.Shot(_enemyView.ShotPoint.position, _detectSystem.PlayerCollider.transform.position);
            }
        }
    }
}