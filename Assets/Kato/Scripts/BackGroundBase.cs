using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 二次元リスト生成のクラス
/// </summary>
[System.SerializableAttribute]
public class ValueList
{
    public List<int> List = new List<int>();

    public ValueList(List<int> list)
    {
        List = list;
    }
}

public class BackGroundBase : MonoBehaviour
{
    [SerializeField]
    protected BackGroundGenerationMaster BGGM;
    [SerializeField]
    protected GameManager gameManager;

    [SerializeField]
    protected Camera cam; //カメラ

    [SerializeField]
    protected float BGChangeTime; //背景が切り替わるフレーム数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
