using UnityEngine;

namespace Player
{
    public class PlayerAnimationCell : PlayerAnimationBase
    {
        [SerializeField] private Transform _body;

        [SerializeField] private Transform _cell;
        [SerializeField] private Transform _core;

        private Vector2 _prevPosition;
        private float _currentAngle;
        private float _currentAngleVelocity;

        private void Update()
        {
            var pos = (Vector2) _body.position;
            var delta = pos - _prevPosition;
            if (delta != Vector2.zero)
            {
                var angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

                _currentAngle = Mathf.SmoothDampAngle(
                    _currentAngle,
                    angle,
                    ref _currentAngleVelocity,
                    0.1f
                );

                _body.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }

            _prevPosition = pos;
        }
    }
}