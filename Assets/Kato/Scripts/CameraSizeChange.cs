using Cinemachine;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class CameraSizeChange : CameraSizeChangeBase
{
    [SerializeField]
    private int evolStage; //最新の進化段階
    [SerializeField]
    private int beforeEvolStage; //前の進化段階

    // Start is called before the first frame update
    void Start()
    {
        vcam.m_Lens.OrthographicSize = CSCM.CSCMRows[0].orthoSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void CamSizeChange()
    {
        if (!CSChanging) CSChangeTime = 0;
        if (CSChanging)
        {
            //if (_CSC) evolStage += 1;
            //_CSC = false;
            evolStage = PlayerEvolution.Instance.Level - 1;
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(CSCM.CSCMRows[beforeEvolStage].orthoSize, CSCM.CSCMRows[evolStage].orthoSize, CSChangeTime);
            CSChangeTime += Time.unscaledDeltaTime;

            if (CSChangeTime > 1.0f)
            {
                beforeEvolStage = evolStage;
                CSChanging = false;
            }
        }
    }
}
