using UnityEngine;

namespace InternalAssets.Settings
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Bullet", order = 0)]
    public class BulletSettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        
        public float Speed => _speed;
    }
}