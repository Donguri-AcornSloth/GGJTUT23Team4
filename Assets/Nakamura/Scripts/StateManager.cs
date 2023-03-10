using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class StateManager<T>
{
    private class State
    {
        public T stateType;
        public Action Enter { get; set; }
        public Func<bool> Update { get; set; }
        public Action Exit { get; set; }

        public State(T t, Action enter, Func<bool> update, Action exit)
        {
            stateType = t;
            Enter = enter;
            Update = update ?? delegate { return true; };
            Exit = exit;
        }
    }

    private Dictionary<T, State> _defineStateDictionary = new Dictionary<T, State>();
    private List<State> _currentStateList = new List<State>();
    private State _currentState = null;
    private int _currentIndex = 0;

    /// <summary>
    /// 全ての動作が終了しているか
    /// </summary>
    public bool IsEnd { get { return _currentStateList.Count <= _currentIndex; } }
    public T CurrentStateType
    {
        get
        {
            if (_currentState == null)
                return default(T);
            return _currentState.stateType;
        }
    }

    public void UpdateState()
    {
        if (IsEnd) return;

        if(_currentState == null)
        {
            _currentState = _currentStateList[_currentIndex];
            _currentState.Enter?.Invoke();
        }

        var isEndState = _currentState.Update();

        if (isEndState)
        {
            _currentState?.Exit();
            _currentIndex++;

            if (IsEnd)
            {
                _currentIndex = 0;
                _currentState = null;
                _currentStateList.Clear();
                return;
            }

            _currentState = _currentStateList[_currentIndex];
            _currentState?.Enter();
        }
    }

    /// <summary>
    /// 行動の定義
    /// </summary>
    /// <param name="t"></param>
    /// <param name="enter"></param>
    /// <param name="update"></param>
    /// <param name="exit"></param>
    public void DefineState(T t, Action enter, Func<bool> update, Action exit)
    {
        var state = new State(t, enter, update, exit);
        var exist = _defineStateDictionary.ContainsKey(t);
        if (exist)
        {
            Debug.LogError("登録したStateは既に追加されています。");
            return;
        }
        _defineStateDictionary.Add(t, state);
    }

    /// <summary>
    /// 行動の登録
    /// </summary>
    /// <param name="t"></param>
    public void AddState(T t)
    {
        State state = null;
        var exist = _defineStateDictionary.TryGetValue(t, out state);
        if(exist == false)
        {
            Debug.LogError("このStateは登録されていません。");
            return;
        }
        _currentStateList.Add(state);
    }

    public void ForceStop()
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = null;
        _currentStateList.Clear();
        _currentIndex = 0;
    }
}
