using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float _targetTime;
    private float _elapsedTime = 0;

    public Timer(float targetTime = 1f)
    {
        if(targetTime <= 0)
        {
            Debug.LogError("0‚æ‚è‘å‚«‚¢’l‚ð“ü‚ê‚Ä‚­‚¾‚³‚¢");
            return;
        }
        this._targetTime = targetTime;
    }

    public bool IsTimeUp { get { return _targetTime <= _elapsedTime; } }
    public float ElapsedTime { get { return _elapsedTime; } }

    public bool Update(float timeScale = 1.0f)
    {
        _elapsedTime += Time.deltaTime * timeScale;
        return IsTimeUp;
    }
    public void ResetTimer(float targetTime)
    {
        _targetTime = targetTime;
        _elapsedTime = 0;
    }
}
