using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackGroundGenerater : BackGroundBase
{
    [SerializeField]
    private int evolStage; //�ŐV�̐i���i�K
    [SerializeField]
    private int beforeEvolStage; //�O�̐i���i�K

    [SerializeField]
    private bool BGChanging; //�w�i��؂�ւ��鎞�̔���
    private bool _BGC;


    //����������
    private void Init()
    {
        evolStage = 0;
        beforeEvolStage = 0;
        BGChanging = false;
        _BGC = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BGChanging = true;
            _BGC = true;
            Debug.Log("1"); 
        }
        BGGenerate();
    }

    //�w�i�̐������\�b�h
    private void BGGenerate()
    {
        if (!BGChanging) BGChangeTime = 0;
        if (BGChanging)
        {
            if (_BGC) evolStage += 1;
            _BGC = false;
            //evolStage = gameManager.
            cam.backgroundColor = Color.Lerp(BGColors[beforeEvolStage], BGColors[evolStage], BGChangeTime);
            BGChangeTime += Time.unscaledDeltaTime;

            if (BGChangeTime > 1.0f)
            {
                beforeEvolStage = evolStage;
                BGChanging = false;
            }

            //Color color = (BGColors[evolStage] - BGColors[beforeEvolStage]);
            //for (int i = 0; i < BGChangeTime; i++)
            //{
            //    cam.backgroundColor += color / BGChangeTime;
            //}
        }
    }
}
