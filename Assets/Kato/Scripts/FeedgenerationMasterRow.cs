using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FeedgenerationMasterRow", menuName = "ScriptableObjects/FeedgenerationMasterRow", order = 2)]
public class FeedgenerationMasterRow : ScriptableObject
{
    public int level; //�i���i�K
    public int maxFeeds; //�a�̃|�b�v���
    public int repopNum; //�a���Đ�������臒l
    public float freqency; //�����Ԋu(1�b�ŉ��������邩)
}
