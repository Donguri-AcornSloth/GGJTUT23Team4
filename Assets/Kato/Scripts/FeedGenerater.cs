using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FeedGenerater : MonoBehaviour, IInitialize
{

    [SerializeField]
    private FeedGenerationMaster FGM;
    //[SerializeField]
    //private List<GameObject> feeds; //��������a�̃��X�g
    public List<GameObject> generatedFeeds; //���������a�̃��X�g
    [SerializeField]
    private float randPosMax;
    [SerializeField]
    private float randPosMin;
    [SerializeField]
    private float generateTime;

    private Transform player;
    Timer _generateTimer = new Timer(1.0f);
    private int level;

    public void Initialize()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        if (generatedFeeds.Count > 0)
        {
            foreach (var f in generatedFeeds)
            {
                if (f != null)
                    Destroy(f);
            }
            
            generatedFeeds.Clear();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerEvolution.Instance.OnLevelChanged.AddListener(FDeleater);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        _generateTimer.Update();
        if (_generateTimer.IsTimeUp)
        {
            FGeneration(PlayerEvolution.Instance.Level - 1);            
            _generateTimer.ResetTimer(generateTime);
        }
    }

    //�a�������\�b�h
    public void FGenerate(int level)
    {
        int feedMode = Random.Range(0, FGM.FGMRows[level].generatingFeeds.Count);
        Vector3 pos = new Vector3(Random.Range(randPosMin, randPosMax), Random.Range(randPosMin, randPosMax), 0);
        if (pos.x > 0) pos.x = Mathf.Max(2.0f, pos.x);
        else pos.x = Mathf.Min(-2.0f, pos.x);
        if (pos.y > 0) pos.y = Mathf.Max(2.0f, pos.y);
        else pos.y = Mathf.Min(-2.0f, pos.y);
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, 0);
        Vector3 generatePos = pos + playerPos;
        GameObject feed = Instantiate(FGM.FGMRows[level].generatingFeeds[feedMode]);
        feed.transform.position = generatePos;
        generatedFeeds.Add(feed);
    }

    public void FGeneration(int level)
    {
        if (generatedFeeds.Count <= FGM.FGMRows[level].maxFeeds)
        {
            for (int i = 0; i < FGM.FGMRows[level].freqency; i++)
            {
                FGenerate(level);
                if (generatedFeeds.Count >= FGM.FGMRows[level].maxFeeds) break;
            }
        }
    }

    public void FDeleater(int level)
    {

        if (generatedFeeds.Count == 0) return;
        foreach (var f in generatedFeeds)
        {
            Destroy(f.gameObject);
        }
        generatedFeeds.Clear();
    }
}
