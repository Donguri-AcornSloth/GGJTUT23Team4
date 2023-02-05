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
        // 対象オブジェクトの子オブジェクトをチェックする
        foreach (Transform child in a_CheckObject.transform)
        {
            // 子オブジェクトのアクティブを切り替える
            GameObject childObject = child.gameObject;
            childObject.SetActive(a);

            // 再帰的に全ての子オブジェクトを処理する
            RecursiveSetActive(childObject, a);
        }
    }
}
