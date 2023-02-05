using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBase : MonoBehaviour
{
    [SerializeField, Tooltip("餌のタイプ(草か肉か)")]
    public FeedType _feedType;
    [SerializeField, Tooltip("餌の毒の有無")]
    public FeedPoison _feedPoison;
    [SerializeField]
    public FeedGenerater _fGen;

    public enum FeedType
    {
        草, //草
        肉, //肉
    }

    public enum FeedPoison
    {
        毒あり, //毒あり
        毒なし, //毒なし
    }

    // Start is called before the first frame update
    void Start()
    {
        _fGen = GameObject.Find("FeedGenerater").GetComponent<FeedGenerater>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        _fGen.generatedFeeds.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 餌自体がPlayerに触れた時の処理
    /// </summary>
    public void PickUp()
    {
        _fGen.generatedFeeds.Remove(this.gameObject);
        //int objNum = _fGen.generatedFeeds.IndexOf(this.gameObject);
        //_fGen.generatedFeeds.RemoveAt(objNum);
        Destroy(this.gameObject);
    }
}
