using System;
using System.Collections.Generic;
using InternalAssets.Scripts.Player;
using InternalAssets.Scripts.Triggers;
using UnityEngine;

namespace InternalAssets.Scripts.Detect
{
    public class DetectSystem
    {
        private PlayerCollider _playerCollider;

        public PlayerCollider PlayerCollider => _playerCollider;

        public void FindObject(EnemyView enemyView, int angle, float distance)
        {
            Vector3 direction = enemyView.VisablePoint.transform.position - enemyView.NavMeshAgent.transform.position;
            Ray ray;
            RaycastHit hit;
            
            for(int i = -angle / 2; i < angle / 2; i+=2)
            {
                ray = new Ray(enemyView.NavMeshAgent.transform.position + Vector3.up, Quaternion.Euler(new Vector3(0,i,0)) * (direction * distance / 2));
                Debug.DrawRay(enemyView.NavMeshAgent.transform.position + Vector3.up, Quaternion.Euler(new Vector3(0,i,0)) * (direction * distance / 2), Color.magenta, 0.05f);
                
                if (Physics.Raycast(ray, out hit, distance))
                {
                    if (hit.collider.TryGetComponent(out PlayerCollider component))
                    {
                        _playerCollider = component;
                        return;
                    }
                }
            }

            _playerCollider = null;
        }
    }
}