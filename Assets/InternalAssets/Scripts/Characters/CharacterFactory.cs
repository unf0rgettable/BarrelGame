using InternalAssets.Scripts.Joysticks;

namespace InternalAssets.Scripts.Player
{
    public class CharacterFactory
    {
        public PlayerContainer GenerateCharacter(Player player, JoystickService joystickService)
        {
            var playerModel = new PlayerModel(player.PlayerSettings);
            return new PlayerContainer(new PlayerPresenter(player.NavMeshAgent,
                    new JoystickInputSystem(joystickService, player.Camera),
                    playerModel),
                player,
                playerModel);
        }
    }
}