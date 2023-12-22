using System;
using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    [Serializable]
    public class Enemy
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private PatrolView _patrolView;

        public EnemyView EnemyView => _enemyView;
        public PatrolView PatrolView => _patrolView;
    }
}