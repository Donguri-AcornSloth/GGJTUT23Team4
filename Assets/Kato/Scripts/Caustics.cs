using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caustics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerEvolution.Instance.Level == 3) RecursiveSetActive(this.gameObject, true);
        else RecursiveSetActive(this.gameObject, false);
    }

    private void RecursiveSetActive(GameObject a_CheckObject, bool a)
    {
        // �ΏۃI�u�W�F�N�g�̎q�I�u�W�F�N�g���`�F�b�N����
        foreach (Transform child in a_CheckObject.transform)
        {
            // �q�I�u�W�F�N�g�̃A�N�e�B�u��؂�ւ���
            GameObject childObject = child.gameObject;
            childObject.SetActive(a);

            // �ċA�I�ɑS�Ă̎q�I�u�W�F�N�g����������
            RecursiveSetActive(childObject, a);
        }
    }
}
