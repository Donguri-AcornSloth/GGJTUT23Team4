using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeChangeBase : MonoBehaviour
{
    [SerializeField]
    protected CinemachineVirtualCamera vcam;
    [SerializeField]
    protected Camera cam; //ƒJƒƒ‰
    [SerializeField]
    protected CameraSizeChangeMaster CSCM;

    [SerializeField]
    protected bool CSChanging; //”wŒi‚ğØ‚è‘Ö‚¦‚é‚Ì”»’è
    protected bool _CSC;

    [SerializeField]
    protected float CSChangeTime; //”wŒi‚ªØ‚è‘Ö‚í‚éƒtƒŒ[ƒ€”

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
