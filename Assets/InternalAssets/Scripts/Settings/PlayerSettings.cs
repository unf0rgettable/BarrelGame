using UnityEngine;

namespace InternalAssets.Settings
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Characters settings/Player", order = 0)]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}