using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FeedGenerater : MonoBehaviour, IInitialize
{

    [SerializeField]
    private FeedGenerationMaster FGM;
    [SerializeField]
    private List<GameObject> feeds; //生成する餌のリスト
    public List<GameObject> generatedFeeds; //生成した餌のリスト

    private GameObject player;

    public void Initialize()
    {
        player = GameObject.Find("Player");
    }
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
        //GameObject feed = Instantiate(feeds[feedMode], )
    }
}
