using InternalAssets.Scripts.Joysticks;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Scripts.Player
{
    public class PlayerPresenter : ITickable
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly JoystickInputSystem _joystickInputSystem;
        private readonly PlayerModel _playerModel;

        public PlayerPresenter(NavMeshAgent navMeshAgent,
            JoystickInputSystem joystickInputSystem,
            PlayerModel playerModel)
        {
            _navMeshAgent = navMeshAgent;
            _joystickInputSystem = joystickInputSystem;
            _playerModel = playerModel;
        }

        public void Tick()
        {
            var inputMagnitude = _joystickInputSystem.Direction.magnitude;
            if (inputMagnitude > 0)
            {
                Vector3 currentPosition = _navMeshAgent.transform.position;
                Vector3 targetPosition = currentPosition + _joystickInputSystem.Direction;
                Vector3 forward = targetPosition - currentPosition;
                Vector3 dir = forward.normalized;
                
                var velocity = forward * _playerModel.Speed;
                _navMeshAgent.Move(velocity * Time.fixedDeltaTime);
                
                _navMeshAgent.transform.forward = dir;
            }
            
        }
    }
}