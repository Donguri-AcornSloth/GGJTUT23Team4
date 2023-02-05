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

    [SerializeField]
    private List<GameObject> caustics;

    private float BGChangeTimes;
    private float causticTimeCount;
    private Transform player;

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
        causticTimeCount = 0;
        player = GameObject.Find("Player").GetComponent<Transform>();
        if (caustics.Count > 0)
        {
            foreach (var f in caustics)
            {
                if (f != null)
                    Destroy(f);
            }

            caustics.Clear();
        }
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
        if (PlayerEvolution.Instance.Level >= 3)
        {
            if (causticTimeCount < BGGM.BGGMRows[PlayerEvolution.Instance.Level - 1].causticGenerateTime) causticTimeCount += Time.deltaTime;
            else Caustics();
        }

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
    }

    //背景の生成メソッド
    private void BGGenerate()
    {
        if (GameManager.Instance.CurrentState != GameManager.StateEnum.Play) return;
        if (!BGChanging) BGChangeTimes = 0;
        if (BGChanging)
        {
            evolStage = PlayerEvolution.Instance.Level - 1;
            cam.backgroundColor = Color.Lerp(BGGM.BGGMRows[beforeEvolStage].BGColors, BGGM.BGGMRows[evolStage].BGColors, BGChangeTime);
            BGChangeTimes += Time.deltaTime;
            colorGrading.saturation.value = BGGM.BGGMRows[evolStage].saturation;
            colorGrading.colorFilter.value = BGGM.BGGMRows[evolStage].colorFilter;
            depthOfField.focusDistance.value = BGGM.BGGMRows[evolStage].focusDistance;

            if (BGChangeTimes > BGChangeTime)
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

    private void Caustics()
    {
        if (causticTimeCount > BGGM.BGGMRows[PlayerEvolution.Instance.Level - 1].causticGenerateTime)
        {
            int r = Random.Range(0, BGGM.BGGMRows[PlayerEvolution.Instance.Level - 1].BGLists.Count);
            var rot = Random.Range(0.0f, 360.0f);
            GameObject caustic = Instantiate(BGGM.BGGMRows[PlayerEvolution.Instance.Level - 1].BGLists[0].List[r]);
            caustic.transform.rotation = Quaternion.Euler(0, 0, rot);
            caustic.transform.localPosition =  new Vector3(5.0f, 0.0f, 0.0f);
            caustics.Add(caustic);
            causticTimeCount = 0f;
        }
    }
}
