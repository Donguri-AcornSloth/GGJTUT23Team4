using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �񎟌����X�g�����̃N���X
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
    protected Camera cam; //�J����

    [SerializeField]
    protected float BGChangeTime; //�w�i���؂�ւ��t���[����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
