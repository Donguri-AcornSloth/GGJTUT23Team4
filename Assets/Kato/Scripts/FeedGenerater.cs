using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedGenerater : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> feeds; //��������a�̃��X�g

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
