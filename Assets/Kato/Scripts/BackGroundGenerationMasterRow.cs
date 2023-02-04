using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "BackGroundGenerationMasterRow", menuName = "ScriptableObjects/BackGroundGenerationMasterRow", order = 2)]
public class BackGroundGenerationMasterRow : ScriptableObject
{
    public List<ValueList> BGLists; //背景として生成するオブジェクトのリスト
    [ColorUsage(true, true), SerializeField]
    public Color BGColors; //背景の色
    public float saturation; //ColorGradingの彩度の値
    [ColorUsage(true, true), SerializeField]
    public Color colorFilter; //背景のフィルターの色
    public float focusDistance; //被写界深度
}
