using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeChangeBase : MonoBehaviour
{
    [SerializeField]
    protected CinemachineVirtualCamera vcam;
    [SerializeField]
    protected Camera cam; //�J����
    [SerializeField]
    protected CameraSizeChangeMaster CSCM;

    [SerializeField]
    protected bool CSChanging; //�w�i��؂�ւ��鎞�̔���
    protected bool _CSC;

    [SerializeField]
    protected float CSChangeTime; //�w�i���؂�ւ��t���[����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
