using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "FeedgenerationMasterRow", menuName = "ScriptableObjects/FeedgenerationMasterRow", order = 2)]
public class FeedgenerationMasterRow : ScriptableObject
{
    public int level; //�i���i�K
    public int maxFeeds; //�a�̃|�b�v���
    public int repopNum; //�a���Đ�������臒l
    public float freqency; //�����Ԋu(1�b�ŉ��������邩)
    public List<GameObject> generatingFeeds; //��������a�̃v���n�u 
}
