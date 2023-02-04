using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedgenerationMasterRow : ScriptableObject
{
    [System.Serializable]
    public int level; //i‰»’iŠK
    public int maxFeeds; //‰a‚Ìƒ|ƒbƒvãŒÀ
    public int repopNum; //‰a‚ğÄ¶¬‚·‚éè‡’l
    public float freqency; //¶¬ŠÔŠu

    List<(int, int, int, float)> level1;
}
