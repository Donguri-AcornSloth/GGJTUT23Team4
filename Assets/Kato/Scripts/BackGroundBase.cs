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
    public List<ValueList> BGLists = new List<ValueList>(); //�w�i�Ƃ��Đ�������I�u�W�F�N�g�̃��X�g
    [SerializeField]
    protected List<Color> BGColors = new List<Color>(); //�w�i�̐F�̃��X�g

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
