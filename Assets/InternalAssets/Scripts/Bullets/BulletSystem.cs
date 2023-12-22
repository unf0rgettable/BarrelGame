using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts.Bullets
{
    public class BulletSystem : ITickable
    {
        private BulletView _bulletViewPrefab;
        public List<BulletView> _bullets = new();

        public BulletSystem(BulletView bulletViewPrefab)
        {
            _bulletViewPrefab = bulletViewPrefab;
        }

        public void Shot(Vector3 shotPoint, Vector3 playerPosition)
        {
            var bulletView = GameObject.Instantiate(_bulletViewPrefab, shotPoint, Quaternion.identity);
            var direction = playerPosition - bulletView.transform.position;
            direction.y = 0;
            bulletView.transform.forward = direction;
            _bullets.Add(bulletView);
            
            bulletView.AutoDestroy(() =>
            {
                _bullets.Remove(bulletView);
            });
        }
        
        public void Tick()
        {
            foreach (var bullet in _bullets)
            {
                bullet.transform.position += bullet.transform.forward * Time.deltaTime * bullet.BulletSettings.Speed;
            }
        }
    }
}