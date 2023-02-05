using System;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            // 餌かどうかの判定処理
            var feed = col.GetComponent<FeedBase>();
            if (feed != null)
            {
                // 餌を食べる処理実施
                feed.PickUp();
                PlayerEvolution.Instance.EatFeed(feed);
            }

            // 敵の判定処理
            var enemy = col.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.ApplyDamage(PlayerEvolution.Instance.AttackValue);
                PlayerEvolution.Instance.ApplyDamage(enemy.AttackValue);

                // 肉食なら敵を食べる
                if (PlayerEvolution.Instance.Type != PlayerEvolution.EvolutionType.Herbivore)
                    PlayerEvolution.Instance.EatEnemy();
            }
        }
    }
}