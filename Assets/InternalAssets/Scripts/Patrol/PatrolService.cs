using UnityEngine;

namespace InternalAssets.Scripts
{
    public class PatrolService
    {
        private PatrolView _patrolView;
        private int _currentPoint;
        private bool _isBack;

        public Transform CurrentPatrolPoint => _patrolView.Points[_currentPoint];
        
        public PatrolService(PatrolView patrolView)
        {
            _patrolView = patrolView;
        }

        public Transform GetNextPoint()
        {
            Transform point = _isBack
                ? _patrolView.Points[_patrolView.Points.Count - 1 - _currentPoint]
                : _patrolView.Points[_currentPoint];

            if (_currentPoint <= 0)
            {
                _isBack = false;
            }
            if(_currentPoint >= _patrolView.Points.Count - 1)
            {
                _isBack = true;
            }
            
            if (_isBack)
            {
                _currentPoint--;
            }
            else
            {
                _currentPoint++;
            }
            
            return point;
        }
    }
}