using System;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// プレイヤーのアニメーション管理
    /// </summary>
    public class PlayerAnimationManager : MonoBehaviour
    {
        [Serializable]
        private struct Row
        {
            public int _id;
            public PlayerAnimationBase _animation;
        }

        [SerializeField] private Row[] _animations;

        private void Awake()
        {
            // 最初は全て消しておく
            for (var i = 0; i < _animations.Length; i++)
            {
                _animations[i]._animation.Hide();
            }
        }
    }
}