using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    private static TimeScale _instance;
    [SerializeField, Range(0.01f, 2f)]
    private float _value = 1.0f;

    public static TimeScale Instance { get { return _instance; } }
    public float Value { get { return _value; } }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetValue(float target)
    {
        _value = target;
    }
}
