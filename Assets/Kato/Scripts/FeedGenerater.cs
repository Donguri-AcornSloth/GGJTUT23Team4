using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FeedGenerater : MonoBehaviour, IInitialize
{
    [SerializeField]
    private List<GameObject> feeds; //��������a�̃��X�g

    public List<GameObject> generatedFeeds;

    public void Initialize()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�a�������\�b�h
    private void FGenerate()
    {
        int feedMode = (int)Random.Range(0, 2);
        GameObject feed = Instantiate(feeds[feedMode], )
    }
}
