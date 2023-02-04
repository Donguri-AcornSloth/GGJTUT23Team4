using Cinemachine;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.U2D;

public class CameraSizeChange : CameraSizeChangeBase
{
    [SerializeField]
    private int evolStage; //�ŐV�̐i���i�K
    [SerializeField]
    private int beforeEvolStage; //�O�̐i���i�K
    private float CSChangeTimes; //�w�i���؂�ւ��t���[����

    // Start is called before the first frame update
    void Start()
    {
        vcam.m_Lens.OrthographicSize = CSCM.CSCMRows[0].orthoSize;
        PlayerEvolution.Instance.OnLevelChanged.AddListener(CamSizeChangeSwitch);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.CurrentState == GameManager.StateEnum.Play)
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
            //vcam.m_Lens.OrthographicSize += (CSCM.CSCMRows[evolStage].orthoSize - CSCM.CSCMRows[beforeEvolStage].orthoSize) / CSChangeTime * Time.deltaTime;
            //vcam.m_Lens.OrthographicSize = Mathf.Clamp(vcam.m_Lens.OrthographicSize, CSCM.CSCMRows[beforeEvolStage].orthoSize, CSCM.CSCMRows[evolStage].orthoSize);
            cam.GetComponent<PixelPerfectCamera>().assetsPPU = (int)(100 * CSCM.CSCMRows[0].orthoSize / CSCM.CSCMRows[evolStage].orthoSize);
            CSChangeTimes += Time.deltaTime;

            if (CSChangeTimes > CSChangeTime)
            {
                beforeEvolStage = evolStage;
                CSChanging = false;
            }
        }
    }
}
