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

            // TODO : 敵の判定処理実装
        }
    }
}