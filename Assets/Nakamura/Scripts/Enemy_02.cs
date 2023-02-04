using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyBase;

public class Enemy_02 : EnemyBase
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
        if(InCircle(transform.position, _player.gameObject.transform.position, _raderRadius))
        {
            if (_stateManager.CurrentStateType == ActionStateEnum.Chase) return;

            _stateManager.ForceStop();
            _stateManager.AddState(ActionStateEnum.Chase);
        }

        DeathspownTimerUpdate();
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
    protected override void OnStateTurnEnter()
    {
        _turnTimer.ResetTimer(_turnTime);
        _turnRate = 0;

        _turnTimer.ResetTimer(_turnTime);
        _turnRate = 0;

        _targetRotation = Quaternion.AngleAxis(Vector3.Angle(_player.gameObject.transform.position, gameObject.transform.position), Vector3.forward) * transform.rotation;
    }
}
