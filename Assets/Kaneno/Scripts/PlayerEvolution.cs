using System;
using UnityEngine;

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

        #endregion

        private void Awake()
        {
            Instance = this;
        }
    }
}