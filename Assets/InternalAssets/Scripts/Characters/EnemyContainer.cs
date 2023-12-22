namespace InternalAssets.Scripts.Player
{
    public class EnemyContainer : ITickable
    {
        public EnemyModel EnemyModel { get; }
        public EnemyView EnemyView { get; }
        public EnemyPresenter EnemyPresenter { get; }

        public EnemyContainer(EnemyModel enemyModel, EnemyView enemyView, EnemyPresenter enemyPresenter)
        {
            EnemyModel = enemyModel;
            EnemyView = enemyView;
            EnemyPresenter = enemyPresenter;
        }

        public void Tick()
        {
            EnemyPresenter.Tick();
        }
    }
}