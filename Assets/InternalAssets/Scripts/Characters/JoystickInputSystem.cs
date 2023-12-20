using InternalAssets.Scripts.Joysticks;
using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class JoystickInputSystem
    {
        private JoystickService _joystickService;
        private readonly Camera _camera;
        private Transform _cameraTransform => _camera.transform;

        private bool _canMove = true;
        public Vector3 StickDirection => _joystickService.CurrentJoystick != null && _canMove ?
            new Vector3(_joystickService.CurrentJoystick.Direction.x, 0, _joystickService.CurrentJoystick.Direction.y) : Vector3.zero;

        public Vector3 Direction => Quaternion.LookRotation(ForwardOffset) * StickDirection;
        public Vector3 ForwardOffset { get; private set; }
        
        public Vector3 CameraForward
        {
            get
            {
                var forward = _cameraTransform.forward;
                forward.y = 0;
                return forward.normalized;
            }
        }
        
        public JoystickInputSystem(JoystickService joystickService, Camera camera)
        {
            _joystickService = joystickService;
            _camera = camera;
        }
    }
}