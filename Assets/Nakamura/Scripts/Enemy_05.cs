using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_05 : EnemyBase
{
    [SerializeField]
    private float _moveSpeed = 1;
    [SerializeField]
    private float _moveTime = 3;
    [SerializeField]
    private float _chaseSpeed = 2;
    [SerializeField]
    private float _chaseTurnSpeed = 1;
    [SerializeField]
    private float _targetPosUpdateInterval = 0.5f;

    private Timer _moveTimer = new Timer();
    private Timer _targetPosUpdateIntervalTimer = new Timer();
    private GameObject _targetObj;

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
        if (InCircle(_player.gameObject.transform.position, _raderRadius))
        {
            if (_stateManager.CurrentStateType == ActionStateEnum.Chase || _stateManager.CurrentStateType == ActionStateEnum.Idle) return;
            _targetObj = _player.gameObject;
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
    protected override void OnStateTurnExit()
    {
        _moveDirection = transform.up;
        _moveDirection.Normalize();
    }
    protected override void OnStateMoveEnter()
    {
        _moveTimer.ResetTimer(_moveTime);
        //_moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        //_moveDirection.Normalize();
    }
    protected override bool OnStateMoveUpdate()
    {
        _rigidbody.velocity = _moveDirection * _moveSpeed;

        _moveTimer.Update();

        return _moveTimer.IsTimeUp;
    }
    protected override void OnStateMoveExit()
    {
        _rigidbody.velocity = Vector2.zero;
    }
    protected override void OnStateIdleExit()
    {
        _rigidbody.velocity = Vector2.zero;
    }
    protected override void OnStateChaseEnter()
    {
        _targetPosUpdateIntervalTimer.ResetTimer(_targetPosUpdateInterval);
        _moveDirection = _targetObj.transform.position - transform.position;
    }
    protected override bool OnStateChaseUpdate()
    {
        /**
        _targetPosUpdateIntervalTimer.Update();

        if (_targetPosUpdateIntervalTimer.IsTimeUp)
        {
            Debug.Log("a");
            _moveDirection = _targetObj.transform.position - transform.position;
            _moveDirection.Normalize();
            _targetPosUpdateIntervalTimer.ResetTimer(_targetPosUpdateInterval);
        }
        **/
        _moveDirection = _targetObj.transform.position - transform.position;
        _moveDirection.Normalize();
        transform.rotation = Quaternion.FromToRotation(Vector3.up, _moveDirection);
        _rigidbody.velocity = _moveDirection * _chaseSpeed;

        return InCircle(_player.gameObject.transform.position, _raderRadius);
    }
    protected override void OnStateChaseExit()
    {
        
    }
}
