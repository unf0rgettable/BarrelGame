using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace InternalAssets.Scripts.Triggers
{
    public class Trigger<T> : MonoBehaviour
    {
        [SerializeField, NaughtyAttributes.ReadOnly] 
        public List<T> OnStayInTrigger = new();

        [SerializeField] private bool _showGizmos = false;
        [SerializeField, ShowIf(nameof(_showGizmos))] Color _color = Color.green;

        private Mesh _mesh;
        public event Action<T> OnEnter; 
        public event Action<T> OnExit; 
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T component))
            {
                OnStayInTrigger.Add(component);
                OnEnter?.Invoke(component);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T component))
            {
                OnStayInTrigger.Remove(component);
                OnExit?.Invoke(component);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (_showGizmos)
            {
                Gizmos.color = _color;
                Gizmos.DrawMesh(
                    GetComponent<MeshFilter>().sharedMesh,
                    transform.position, 
                    transform.rotation, 
                    transform.lossyScale);
            }
        }
    }
}