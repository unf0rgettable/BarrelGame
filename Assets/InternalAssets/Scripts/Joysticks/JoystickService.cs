namespace InternalAssets.Scripts.Joysticks
{
    public class JoystickService
    {
        private Joystick _floatingJoystick;

        public Joystick CurrentJoystick => _floatingJoystick;

        public JoystickService(Joystick floatingJoystick)
        {
            _floatingJoystick = floatingJoystick;
        }
    }
}