using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedgenerationMasterRow : ScriptableObject
{
    [System.Serializable]
    public int level; //進化段階
    public int maxFeeds; //餌のポップ上限
    public int repopNum; //餌を再生成する閾値
    public float freqency; //生成間隔

    List<(int, int, int, float)> level1;
}
