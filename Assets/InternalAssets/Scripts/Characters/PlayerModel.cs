using PlayerSettings = InternalAssets.Settings.PlayerSettings;

namespace InternalAssets.Scripts.Player
{
    public class PlayerModel
    {
        private readonly PlayerSettings _playerSettings;
        
        public float Speed => _playerSettings.Speed;

        public PlayerModel(PlayerSettings playerSettings)
        {
            _playerSettings = playerSettings;
        }
    }
}