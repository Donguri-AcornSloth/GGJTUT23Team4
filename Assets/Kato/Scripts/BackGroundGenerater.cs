using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerater : BackGroundBase
{
    [SerializeField]
    private bool BGChanging; //�w�i��؂�ւ��鎞�̔���

    [SerializeField]
    private int evolStage; //�i���i�K

    public void 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BGGenerate()
    {
        cam.backgroundColor = BGColors[0];
    }
}
