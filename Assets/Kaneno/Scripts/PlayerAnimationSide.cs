using UnityEngine;

namespace Player
{
    public class PlayerAnimationSide : PlayerAnimationBase
    {
        [SerializeField] private Transform _body;
        [SerializeField] private bool _flipX;

        private Vector2 _prevPosition;
        private float _currentAngle;
        private float _currentAngleVelocity;

        private void Update()
        {
            var pos = (Vector2) _body.position;
            var delta = pos - _prevPosition;
            if (delta != Vector2.zero)
            {
                // 左右の振り向き
                var dir = Vector2.Dot(delta, Vector2.right);

                if (!Mathf.Approximately(dir, 0))
                {
                    dir = Mathf.Sign(dir);
                    if (_flipX) dir = -dir;
                    _body.localScale = new Vector3(dir, 1, 1);

                }

                // var angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
                //
                // _currentAngle = Mathf.SmoothDampAngle(
                //     _currentAngle,
                //     angle,
                //     ref _currentAngleVelocity,
                //     0.1f
                // );

                // _body.rotation = Quaternion.Euler(0, 0, _currentAngle);
            }

            _prevPosition = pos;
        }
    }
}