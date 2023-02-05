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
                // 餌を食べるロジック
                if (PlayerEvolution.Instance.Level <= 2)
                {
                    // 第２形態以前はどれでも食べられる
                    feed.PickUp();
                    PlayerEvolution.Instance.EatFeed(feed);
                }
                else
                {
                    // 第３形態以降は食べられる餌が限られる
                    print($"第３形態以降は食べられる餌が限られる - Type = {PlayerEvolution.Instance.Type}, FeedType = {feed._feedType}");
                    switch (PlayerEvolution.Instance.Type)
                    {
                        case PlayerEvolution.EvolutionType.Carnivorous:
                            if (feed._feedType == FeedBase.FeedType.肉)
                            {
                                feed.PickUp();
                                PlayerEvolution.Instance.EatFeed(feed);
                            }

                            break;

                        case PlayerEvolution.EvolutionType.Omnivorous:
                            feed.PickUp();
                            PlayerEvolution.Instance.EatFeed(feed);
                            break;

                        case PlayerEvolution.EvolutionType.Herbivore:
                            if (feed._feedType == FeedBase.FeedType.草)
                            {
                                feed.PickUp();
                                PlayerEvolution.Instance.EatFeed(feed);
                            }

                            break;
                    }
                }
            }

            // 敵の判定処理
            var enemy = col.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.ApplyDamage(PlayerEvolution.Instance.AttackValue);
                PlayerEvolution.Instance.ApplyDamage(enemy.AttackValue);

                // 敵を食べるロジック
                switch (PlayerEvolution.Instance.Type)
                {
                    case PlayerEvolution.EvolutionType.Carnivorous:
                        // 肉食なら自分の世代以下の生物食べられる
                        PlayerEvolution.Instance.EatEnemy();
                        break;

                    case PlayerEvolution.EvolutionType.Omnivorous:
                        // 肉食なら自分の世代未満の生物食べられる
                        PlayerEvolution.Instance.EatEnemy();
                        break;

                    default:
                        // それ以外は無理
                        break;
                }
            }
        }
    }
}