using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class FeedBase : MonoBehaviour
{
    [SerializeField, Tooltip("餌のタイプ(草か肉か)")]
    protected FeedType _feedType;
    [SerializeField, Tooltip("餌の毒の有無")]
    protected FeedPoison _feedPoison;

    protected enum FeedType
    {
        草, //草
        肉, //肉
    }

    protected enum FeedPoison
    {
        毒あり, //毒あり
        毒なし, //毒なし
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void PickUp()
    {
        Destroy(this.gameObject);
    }
}
