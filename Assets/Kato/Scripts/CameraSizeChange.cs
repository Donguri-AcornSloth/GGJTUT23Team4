using Cinemachine;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class CameraSizeChange : CameraSizeChangeBase
{
    [SerializeField]
    private int evolStage; //ÅV‚Ìi‰»’iŠK
    [SerializeField]
    private int beforeEvolStage; //‘O‚Ìi‰»’iŠK
    private float CSChangeTimes; //”wŒi‚ªØ‚è‘Ö‚í‚éƒtƒŒ[ƒ€”

    // Start is called before the first frame update
    void Start()
    {
        vcam.m_Lens.OrthographicSize = CSCM.CSCMRows[0].orthoSize;
        PlayerEvolution.Instance.OnLevelChanged.AddListener(CamSizeChangeSwitch);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CamSizeChange();
    }

    private void CamSizeChangeSwitch(int level)
    {
        CSChanging = true;
    }

    private void CamSizeChange()
    {
        if (!CSChanging) CSChangeTimes = 0;
        if (CSChanging)
        {
            //if (_CSC) evolStage += 1;
            //_CSC = false;
            evolStage = PlayerEvolution.Instance.Level - 1;
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(CSCM.CSCMRows[beforeEvolStage].orthoSize, CSCM.CSCMRows[evolStage].orthoSize, CSChangeTime);
            CSChangeTimes += Time.deltaTime;

            if (CSChangeTimes > CSChangeTime)
            {
                beforeEvolStage = evolStage;
                CSChanging = false;
            }
        }
    }
}
