using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour, IInitialize
{
    public void Initialize()
    {
        Debug.Log("B");
    }
}
