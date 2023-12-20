namespace InternalAssets.Scripts.Player
{
    public class PlayerContainer : ITickable
    {
        public PlayerPresenter PlayerPresenter { get; }
        public Player Player { get; }
        public PlayerModel PlayerModel { get; }

        public PlayerContainer(PlayerPresenter playerPresenter, Player player, PlayerModel playerModel)
        {
            PlayerPresenter = playerPresenter;
            Player = player;
            PlayerModel = playerModel;
        }

        public void Tick()
        {
            PlayerPresenter.Tick();
        }
    }
}