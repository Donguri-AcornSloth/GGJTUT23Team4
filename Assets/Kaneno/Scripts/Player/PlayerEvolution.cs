using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerEvolution : MonoBehaviour, IInitialize
    {
        [SerializeField] private PlayerEvolutionMaster _master;
        [SerializeField] private Transform _playerCenterPosition;

        public static PlayerEvolution Instance { get; private set; }

        #region パラメータ

        /// <summary>
        /// 進化の段階
        /// </summary>
        public int Level { get; private set; } = 1;

        /// <summary>
        /// 現在の餌ポイント
        /// </summary>
        public float FeedPoint => _feedPointCarnivorous + _feedPointHerbivore;

        /// <summary>
        /// 進化までのゲージ割合(0～1)
        /// 1になったら次の段階に進化する
        /// </summary>
        public float Percentage => FeedPoint / _nextFeedPoint;

        /// <summary>
        /// ヒットポイント
        /// </summary>
        public float HitPoint { get; private set; } = 80; // TODO : あとでマスタから読み込むようにする

        /// <summary>
        /// ヒットポイントの最大値
        /// </summary>
        public float HitPointMax { get; private set; } = 100;

        /// <summary>
        /// ヒットポイントの割合
        /// </summary>
        public float HitPointPercentage => HitPoint / HitPointMax;

        /// <summary>
        /// 攻撃力
        /// </summary>
        public float AttackValue { get; private set; }

        // 現在の形態ID
        public int EvolutionID { get; private set; }

        // 肉食の餌ポイント
        private float _feedPointCarnivorous;

        // 草食の餌ポイント
        private float _feedPointHerbivore;

        // 次の進化に必要な合計餌ポイント
        private float _nextFeedPoint;

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
        /// ゲームプレイ開始通知
        /// </summary>
        public UnityEvent OnStarted { get; } = new();

        /// <summary>
        /// レベルが変わった通知
        /// </summary>
        public UnityEvent<int> OnLevelChanged { get; } = new();

        /// <summary>
        /// 進化したことを知らせる通知
        /// </summary>
        public UnityEvent<PlayerEvolutionMaster.Row> OnEvolution { get; } = new();

        /// <summary>
        /// プレイヤー死亡通知
        /// </summary>
        public UnityEvent OnDead { get; } = new();

        /// <summary>
        /// 餌食べた通知
        /// </summary>
        public UnityEvent OnEatFeed { get; } = new();

        #endregion

        #region メッセージ

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        #region ゲームロジック

        /// <summary>
        /// ゲーム開始
        /// </summary>
        public void Initialize()
        {
            // 生きている状態にする
            State = PlayerState.Living;
            Level = 1;

            // 最初は1段階目
            SetEvolution(1);

            OnStarted?.Invoke();
            OnLevelChanged?.Invoke(1);
        }

        // 進化の段階指定
        private void SetEvolution(int id)
        {
            print($"次の進化ID : {id}");

            var row = Array.Find(_master._rows, x => x._id == id);

            EvolutionID = row._id;
            _nextFeedPoint = row._nextFeedPoint;

            _feedPointCarnivorous = 0;
            _feedPointHerbivore = 0;

            HitPointMax = row._hitPoint;
            HitPoint = row._hitPoint;
            AttackValue = row._attackValue;

            Type = row._type;

            OnEvolution?.Invoke(row);
        }

        // プレイヤー自身にダメージ与える(内部的に使う想定)
        public void ApplyDamage(float damage)
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

        // 餌を食べる
        public void EatFeed(FeedBase feed)
        {
            // 肉・草の判定
            // TODO : 後からパラメータ戻す
            switch (feed._feedType)
            {
                case FeedBase.FeedType.肉:
                    _feedPointCarnivorous += 30;
                    break;

                case FeedBase.FeedType.草:
                    _feedPointHerbivore += 30;
                    break;
            }

            if (Percentage >= 1)
            {
                if (Level < _master._maxLevel)
                {
                    // レベルアップ処理
                    Level++;

                    OnLevelChanged?.Invoke(Level);

                    var rate = _feedPointCarnivorous / FeedPoint;
                    print($"肉食の餌割合 : {rate}");

                    var row = _master.GetRow(EvolutionID);
                    for (var i = 0; i < row._nextEvolutionPaths.Length; i++)
                    {
                        var path = row._nextEvolutionPaths[i];
                        if (path._carnivorousRateThreshold <= rate)
                        {
                            if (path._nextID <= 0) continue;

                            SetEvolution(path._nextID);
                            break;
                        }
                    }
                }
                else
                {
                    // ステージクリア
                    State = PlayerState.None;
                    GameManager.Instance.ChangeState(GameManager.StateEnum.Clear);
                }
            }
            
            OnEatFeed?.Invoke();
        }

        #endregion
    }
}