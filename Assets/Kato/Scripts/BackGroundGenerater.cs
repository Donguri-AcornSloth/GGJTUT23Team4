using Player;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BackGroundGenerater : BackGroundBase
{
    [SerializeField]
    private int evolStage; //最新の進化段階
    [SerializeField]
    private int beforeEvolStage; //前の進化段階

    [SerializeField]
    private bool BGChanging; //背景を切り替える時の判定
    private bool _BGC;

    [SerializeField]
    private PostProcessVolume postProcessVolume;
    private PostProcessProfile postProcessProfile;
    private ColorGrading colorGrading;
    private DepthOfField depthOfField;

    //初期化処理
    private void Init()
    {
        evolStage = 0;
        beforeEvolStage = 0;
        BGChanging = false;
        _BGC = false;
        postProcessProfile = postProcessVolume.profile;
        colorGrading = postProcessProfile.GetSetting<ColorGrading>();
        depthOfField = postProcessProfile.GetSetting<DepthOfField>();
        cam.backgroundColor = BGGM.BGGMRows[0].BGColors;
        colorGrading.saturation.value = BGGM.BGGMRows[0].saturation;
        colorGrading.colorFilter.value = BGGM.BGGMRows[0].colorFilter;
        depthOfField.focusDistance.value = BGGM.BGGMRows[0].focusDistance;
        //colorGrading = postProcessVolume.GetComponent<ColorGrading>();
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

    //背景の生成メソッド
    private void BGGenerate()
    {
        if (!BGChanging) BGChangeTime = 0;
        if (BGChanging)
        {
            if (_BGC) evolStage += 1;
            _BGC = false;
            evolStage = PlayerEvolution.Instance.Level;
            cam.backgroundColor = Color.Lerp(BGGM.BGGMRows[beforeEvolStage].BGColors, BGGM.BGGMRows[evolStage].BGColors, BGChangeTime);
            BGChangeTime += Time.unscaledDeltaTime;
            colorGrading.saturation.value = BGGM.BGGMRows[evolStage].saturation;
            colorGrading.colorFilter.value = BGGM.BGGMRows[evolStage].colorFilter;
            depthOfField.focusDistance.value = BGGM.BGGMRows[evolStage].focusDistance;

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
