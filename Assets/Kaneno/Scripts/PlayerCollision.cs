using System;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            print("OnTriggerEnter2D");
            
            // TODO : アイテム、敵などの当たり判定
            
            // 一旦は全て餌とみなして仮実装
            var feed = col.GetComponent<FeedBase>();
            if (feed != null)
            {
                feed.PickUp();
            }
        }
    }
}
