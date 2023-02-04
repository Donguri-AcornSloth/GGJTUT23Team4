using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Tests
{
    public class TestPlayerEvolution : MonoBehaviour
    {
        private void Update()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null) return;

            // ゲーム開始
            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                PlayerEvolution.Instance.Initialize();
            }

            // プレイヤーの進化情報を出力
            if (keyboard.enterKey.wasPressedThisFrame)
            {
                Debug.Log($"PlayerEvolution.Instance : {PlayerEvolution.Instance}");
                Debug.Log($"PlayerEvolution.Instance.Level : {PlayerEvolution.Instance.Level}");
                Debug.Log($"PlayerEvolution.Instance.Percentage : {PlayerEvolution.Instance.Percentage}");
                Debug.Log($"PlayerEvolution.Instance.Type : {PlayerEvolution.Instance.Type}");
            }
        }
    }
}