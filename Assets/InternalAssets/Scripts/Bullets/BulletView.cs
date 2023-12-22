using System;
using System.Collections;
using InternalAssets.Settings;
using UnityEngine;

namespace InternalAssets.Scripts.Bullets
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private BulletSettings _bulletSettings;

        public BulletSettings BulletSettings => _bulletSettings;

        public void AutoDestroy(Action destroy)
        {
            StartCoroutine(DestroyBullet(destroy));
        }

        IEnumerator DestroyBullet(Action destroy)
        {
            yield return new WaitForSeconds(10f);
            destroy?.Invoke();
            Destroy(gameObject);
        }
    }
}