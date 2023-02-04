using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        // プレイヤー移動の速さ
        [SerializeField] private float _speed = 1;

        private Vector2 _inputMove;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.started) return;

            _inputMove = context.ReadValue<Vector2>();
        }

        private void Awake()
        {
            // 形態に応じた速さを反映する（イベント登録）
            PlayerEvolution.Instance.OnEvolution.AddListener(row => _speed = row._movementSpeed);
        }

        private void Update()
        {
            if (PlayerEvolution.Instance.State != PlayerEvolution.PlayerState.Living)
                return;

            var velocity = _inputMove * _speed;
            transform.localPosition += (Vector3) velocity * Time.deltaTime;
        }
    }
}