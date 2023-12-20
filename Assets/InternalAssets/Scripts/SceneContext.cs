using System.Collections;
using System.Collections.Generic;
using InternalAssets.Scripts;
using InternalAssets.Scripts.Joysticks;
using InternalAssets.Scripts.Player;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Joystick _joystickView;

    private CharacterFactory _characterFactory;
    private JoystickService _joystickService;

    private List<ITickable> _tickables = new();
    void Start()
    {
        _joystickService = new JoystickService(_joystickView);
        _characterFactory = new CharacterFactory();
        _tickables.Add(_characterFactory.GenerateCharacter(_player, _joystickService));
    }
    
    void Update()
    {
        foreach (var tickable in _tickables)
        {
            tickable.Tick();
        }
    }
}
