using UnityEngine;

namespace InternalAssets.Settings
{
    [CreateAssetMenu(fileName = "EnemySetting", menuName = "Characters settings/Enemy", order = 0)]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _attackRangeRadius;
        [SerializeField] private int _attackDegree;

        public int AttackDegree => _attackDegree;
        public float Speed => _speed;
        public float AttackRangeRadius => _attackRangeRadius;
    }
}