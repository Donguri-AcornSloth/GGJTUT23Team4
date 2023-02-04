using Player;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Events;

public class BackGroundGenerater : BackGroundBase, IInitialize
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

    public void Initialize()
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
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerEvolution.Instance.OnLevelChanged.AddListener(BackGroundGenerate);
        PlayerEvolution.Instance.OnLevelChanged.AddListener(BGGenerateSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if(PlayerEvolution.Instance.OnLevelChanged)
        //{
        //    BGChanging = true;
        //    _BGC = true;
        //}
        BGGenerate();
    }

    //private void BackGroundGenerate(int level)
    //{
    //    evolStage = level;
    //    // cam.backgroundColor = Color.Lerp(BGGM.BGGMRows[beforeEvolStage].BGColors, BGGM.BGGMRows[evolStage - 1].BGColors, BGChangeTime);
    //    cam.backgroundColor = Color.Lerp(BGGM.BGGMRows[beforeEvolStage].BGColors, BGGM.BGGMRows[evolStage - 1].BGColors, 1);
    //    BGChangeTime += Time.unscaledDeltaTime;
    //    colorGrading.saturation.value = BGGM.BGGMRows[evolStage - 1].saturation;
    //    colorGrading.colorFilter.value = BGGM.BGGMRows[evolStage - 1].colorFilter;
    //    depthOfField.focusDistance.value = BGGM.BGGMRows[evolStage - 1].focusDistance;

    //    if (BGChangeTime > 1.0f)
    //    {
    //        beforeEvolStage = evolStage - 1;
    //        BGChanging = false;
    //    }
    //}

    private void BGGenerateSwitch(int level)
    {
        BGChanging = true;
        _BGC = true;
    }

    //背景の生成メソッド
    private void BGGenerate()
    {
        if (!BGChanging) BGChangeTime = 0;
        if (BGChanging)
        {
            //if (_BGC) evolStage += 1;
            //_BGC = false;
            evolStage = PlayerEvolution.Instance.Level - 1;
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
