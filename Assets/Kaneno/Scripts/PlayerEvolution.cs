using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerEvolution : MonoBehaviour, IInitialize
    {
        public static PlayerEvolution Instance { get; private set; }

        #region 初期化

        public void Initialize()
        {
            // TODO : 初期化処理などを実装していく
        }

        #endregion

        #region パラメータ

        /// <summary>
        /// 進化の段階
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// 進化までのゲージ割合(0～1)
        /// 1になったら次の段階に進化する
        /// </summary>
        public float Percentage { get; private set; }

        /// <summary>
        /// ヒットポイント
        /// </summary>
        public float HitPoint { get; private set; } = 100; // TODO : あとでマスタから読み込むようにする

        /// <summary>
        /// 進化の形態
        /// </summary>
        public enum EvolutionType
        {
            // なし
            None,

            // 草食
            Herbivore,

            // 肉食
            Carnivorous,

            // 雑食
            Omnivorous,
        }

        public EvolutionType Type { get; private set; } = EvolutionType.None;

        /// <summary>
        /// プレイヤー状態
        /// </summary>
        public enum PlayerState
        {
            None,

            /// <summary>
            /// 初期状態
            /// </summary>
            Initialized,

            /// <summary>
            /// 生きている
            /// </summary>
            Living,

            /// <summary>
            /// 死んでいる
            /// </summary>
            Dead,
        }

        public PlayerState State { get; private set; } = PlayerState.None;

        #endregion

        #region 通知

        /// <summary>
        /// プレイヤー死亡通知
        /// </summary>
        public UnityEvent OnDead { get; } = new();

        #endregion

        #region メッセージ

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region ゲームロジック

        // プレイヤー自身にダメージ与える(内部的に使う想定)
        private void ApplyDamage(float damage)
        {
            if (State != PlayerState.Living)
                return;

            // 体力減らす
            HitPoint -= damage;

            if (HitPoint <= 0)
            {
                // 体力が尽きたら死亡状態に遷移
                State = PlayerState.Dead;
                OnDead?.Invoke();
            }
        }

        #endregion
    }
}