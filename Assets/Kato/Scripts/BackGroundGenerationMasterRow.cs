using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "BackGroundGenerationMasterRow", menuName = "ScriptableObjects/BackGroundGenerationMasterRow", order = 2)]
public class BackGroundGenerationMasterRow : ScriptableObject
{
    public List<ValueList> BGLists; //�w�i�Ƃ��Đ�������I�u�W�F�N�g�̃��X�g
    [ColorUsage(true, true), SerializeField]
    public Color BGColors; //�w�i�̐F
    public float saturation; //ColorGrading�̍ʓx�̒l
    [ColorUsage(true, true), SerializeField]
    public Color colorFilter; //�w�i�̃t�B���^�[�̐F
    public float focusDistance; //��ʊE�[�x
}
