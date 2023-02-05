using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyBase;

public class Enemy_04 : EnemyBase
{
    [SerializeField]
    private float _moveSpeed = 1;
    [SerializeField]
    private float _moveTime = 3;

    private Timer _moveTimer = new Timer();

    // Start is called before the first frame update
    void Start()
    {
        SetPlayer();
        DefineState();
        ChangeState(StateEnum.Move);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateState();
        DeathspownTimerUpdate();
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
