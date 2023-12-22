using System.Collections.Generic;
using InternalAssets.Scripts.Bullets;
using InternalAssets.Scripts.Detect;
using InternalAssets.Scripts.Joysticks;
using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class CharacterFactory
    {
        private List<EnemyContainer> _currentEnemyList = new();

        public List<EnemyContainer> CurrentEnemyList => _currentEnemyList;

        public PlayerContainer GenerateCharacter(Player player, JoystickService joystickService, Camera camera, Transform spawnPoint, FinishService finishService)
        {
            var playerInstance = GameObject.Instantiate(player, spawnPoint);

            var playerModel = new PlayerModel(playerInstance.PlayerSettings);
            
            return new PlayerContainer(new PlayerPresenter(new JoystickInputSystem(joystickService, camera),
                    playerModel,
                    playerInstance,
                    finishService),
                playerInstance,
                playerModel);
        }

        public EnemyContainer GenerateEnemy(Enemy enemy, BulletSystem bulletSystem)
        {
            var enemyModel = new EnemyModel(enemy.EnemyView.EnemySettings);


            var enemyContainer = new EnemyContainer(enemyModel,
                enemy.EnemyView,
                new EnemyPresenter(enemy.EnemyView,
                    new PatrolService(enemy.PatrolView),
                    enemyModel,
                    bulletSystem,
                    new DetectSystem()));
            
            _currentEnemyList.Add(enemyContainer);
            return enemyContainer;
        }
    }
}