using System;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerEvolutionMaster", menuName = "ScriptableObjects/PlayerEvolutionMaster",
        order = 2)]
    public class PlayerEvolutionMaster : ScriptableObject
    {
        /// <summary>
        /// 最大レベル
        /// </summary>
        public int _maxLevel = 3;

        [Serializable]
        public struct NextEvolutionPath
        {
            // 肉食側に進化が必要な割合の閾値
            [Range(0, 1)] public float _carnivorousPercentageThreshold;

            // 次の進化レコードID
            public int _nextID;
        }

        /// <summary>
        /// 各進化情報レコード
        /// </summary>
        [Serializable]
        public struct Row
        {
            public string _name;
            public int _id;
            public PlayerEvolution.EvolutionType _type;
            public float _attackValue;
            public float _hitPoint;
            public float _nextFeedPoint;
            public float _movementSpeed;

            // 成長経路情報リスト
            public NextEvolutionPath[] _nextEvolutionPaths;
        }

        public Row[] _rows;
    }
}