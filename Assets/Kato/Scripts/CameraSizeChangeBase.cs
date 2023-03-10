using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeChangeBase : MonoBehaviour
{
    [SerializeField]
    protected CinemachineVirtualCamera vcam;
    [SerializeField]
    protected Camera cam; //カメラ
    [SerializeField]
    protected CameraSizeChangeMaster CSCM;

    [SerializeField]
    protected bool CSChanging; //背景を切り替える時の判定
    protected bool _CSC;

    [SerializeField]
    protected float CSChangeTime; //背景が切り替わるフレーム数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
