using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "FeedgenerationMasterRow", menuName = "ScriptableObjects/FeedgenerationMasterRow", order = 2)]
public class FeedgenerationMasterRow : ScriptableObject
{
    public int level; //進化段階
    public int maxFeeds; //餌のポップ上限
    public int repopNum; //餌を再生成する閾値
    public float freqency; //生成間隔(1秒で何個生成するか)
    public List<GameObject> generatingFeeds; //生成する餌のプレハブ 
}
