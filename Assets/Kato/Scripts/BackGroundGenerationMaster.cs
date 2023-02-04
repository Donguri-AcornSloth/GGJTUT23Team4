using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackGroundGenerationMaster", menuName = "ScriptableObjects/BackGroundGenerationMaster", order = 2)]
public class BackGroundGenerationMaster : ScriptableObject
{
    public List<BackGroundGenerationMasterRow> BGGMRows;
}
