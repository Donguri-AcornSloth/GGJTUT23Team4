using UnityEngine;

namespace Player
{
    /// <summary>
    /// 形態・種類ごとの個別アニメーション基底
    /// </summary>
    public class PlayerAnimationBase : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}