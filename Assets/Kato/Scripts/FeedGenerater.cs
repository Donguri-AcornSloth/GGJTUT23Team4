using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedGenerater : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> feeds; //生成する餌のリスト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //餌生成メソッド
    private void FGenerate()
    {
        int feedMode = (int)Random.Range(0, 2);
        GameObject feed = Instantiate(feeds[feedMode], )
    }
}
