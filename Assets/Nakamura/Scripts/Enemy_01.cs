using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Enemy_01 : EnemyBase
{
    [SerializeField]
    private float _moveSpeed = 1;
    [SerializeField]
    private float _moveTime = 3;

    private Timer _moveTimer = new Timer();

    // Start is called before the first frame update
    void Start()
    {
        DefineState();
        ChangeState(StateEnum.Move);
    }

    private void OnEnable()
    {
        Debug.Log("ê∂ê¨Ç≥ÇÍÇΩ");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetPlayer();
        UpdateState();
    }

    protected override void SelectActionState()
    {
        _stateManager.AddState(ActionStateEnum.Turn);
        _stateManager.AddState(ActionStateEnum.Move);
    }
    protected override void OnStateMoveEnter()
    {
        _moveTimer.ResetTimer(_moveTime);
    }
    protected override bool OnStateMoveUpdate()
    {
        transform.position += transform.up * _moveSpeed * Time.deltaTime;

        _moveTimer.Update();

        return _moveTimer.IsTimeUp;
    }
}
