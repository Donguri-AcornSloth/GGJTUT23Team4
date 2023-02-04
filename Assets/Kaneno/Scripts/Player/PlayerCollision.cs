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
                print($"enemy.AttackValue = {enemy.AttackValue}");
                
                enemy.ApplyDamage(PlayerEvolution.Instance.AttackValue);
                PlayerEvolution.Instance.ApplyDamage(enemy.AttackValue);    
            }
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Alpha1))
        //     {
        //         PlayerEvolution.Instance.ApplyDamage(100000);
        //     }
        // }
    }
}