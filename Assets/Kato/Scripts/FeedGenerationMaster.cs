using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FeedGenerationMaster", menuName = "ScriptableObjects/FeedGenerationMaster", order = 2)]
public class FeedGenerationMaster : ScriptableObject
{
    public List<FeedgenerationMasterRow> FGMRows;
}
