using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedgenerationMasterRow : ScriptableObject
{
    [System.Serializable]
    public int level; //�i���i�K
    public int maxFeeds; //�a�̃|�b�v���
    public int repopNum; //�a���Đ�������臒l
    public float freqency; //�����Ԋu

    List<(int, int, int, float)> level1;
}
