using System.Collections.Generic;
using InternalAssets.Scripts;
using InternalAssets.Scripts.Bullets;
using InternalAssets.Scripts.Joysticks;
using InternalAssets.Scripts.Level;
using InternalAssets.Scripts.Player;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Joystick _joystickView;
    [SerializeField] private List<LevelView> _levelViews;
    [SerializeField] private BulletView _bulletView;
    
    private CharacterFactory _characterFactory;
    private JoystickService _joystickService;
    private FinishService _finishService;
    private BulletSystem _bulletSystem;

    private PlayerContainer _playerContainer;
    private List<ITickable> _tickables = new();

    private int _currentLevelIndex;
    private LevelView _currentLevelView;
    private void Start()
    {
        _joystickService = new JoystickService(_joystickView);
        _characterFactory = new CharacterFactory();
        _bulletSystem = new BulletSystem(_bulletView);
        
        _tickables.Add(_bulletSystem);
        
        LoadLevel();
    }
    
    private void Update()
    {
        foreach (var tickable in _tickables)
        {
            tickable.Tick();
        }
    }

    public void LoadLevel()
    {
        if (_currentLevelView != null)
            DestroyCurrentLevel();
        
        _currentLevelView = Instantiate(_levelViews[_currentLevelIndex]);
        _finishService = new FinishService();
        _playerContainer = _characterFactory.GenerateCharacter(_playerPrefab, _joystickService, _currentLevelView.Camera, _currentLevelView.SpawnPoint, _finishService);
        _tickables.Add(_playerContainer);

        _finishService.OnFinish += NextLevel;
        _finishService.OnDie += ReloadLevel;
        
        foreach (var enemy in _currentLevelView.Enemy)
        {
            var enemyContainer = _characterFactory.GenerateEnemy(enemy, _bulletSystem);
            
            _tickables.Add(enemyContainer);
        }
    }

    private void ReloadLevel()
    {
        LoadLevel();
    }
    
    private void NextLevel()
    {
        if (_currentLevelIndex == _levelViews.Count - 1)
        {
            ReloadLevel();
        }
        else
        {
            _currentLevelIndex++;
            LoadLevel();
        }
    }
    
    private void DestroyCurrentLevel()
    {
        foreach (var enemy in _characterFactory.CurrentEnemyList)
        {
            _tickables.Remove(enemy);
        }

        foreach (var bullet in _bulletSystem._bullets)
        {
            Destroy(bullet.gameObject);
        }
        
        _bulletSystem._bullets.Clear();
        
        _tickables.Remove(_playerContainer);
        
        _characterFactory.CurrentEnemyList.Clear();
        
        Destroy(_currentLevelView.gameObject);
    }
}
