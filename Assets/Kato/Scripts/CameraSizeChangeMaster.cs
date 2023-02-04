using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSizeChangeMaster", menuName = "ScriptableObjects/CameraSizeChangeMaster", order = 2)]
public class CameraSizeChangeMaster : ScriptableObject
{
    public List<CameraSizeChangeMasterRow> CSCMRows;
}
