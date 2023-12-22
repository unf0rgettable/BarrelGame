using InternalAssets.Settings;

namespace InternalAssets.Scripts.Player
{
    public class EnemyModel
    {
        private EnemySettings _enemySettings;

        public float Speed => _enemySettings.Speed;
        public float AttackRangeRadius => _enemySettings.AttackRangeRadius;
        public int AttackDegree => _enemySettings.AttackDegree;
        public EnemyModel(EnemySettings enemySettings)
        {
            _enemySettings = enemySettings;
        }
    }
}