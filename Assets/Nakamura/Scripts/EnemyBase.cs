using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class EnemyBase : MonoBehaviour
{
    public enum EnemyTypeEnum
    {
        Enemy_01,
        Enemy_02,
        Enemy_03
    }

    public enum StateEnum
    {
        None,
        Move,
        Dead
    }
    public enum ActionStateEnum
    {
        Idle,
        Move,
        Turn,
        Chase,
        Escape,
        Attack_01,
        Attack_02
    }

    [SerializeField]
    protected EnemyTypeEnum _enemyType;
    [SerializeField]
    protected float _attackValue;
    [SerializeField]
    protected float _currentHP;
    [SerializeField]
    protected float _turnTime = 3f;

    [SerializeField]
    protected Rigidbody2D _rigidbody = null;

    protected StateEnum _currentState;
    protected StateManager<ActionStateEnum> _stateManager = new StateManager<ActionStateEnum>();
    protected Timer _turnTimer = new Timer();
    protected float _nextAngle;
    protected Quaternion _targetRotation;
    protected float _turnRate = 0;
    protected PlayerMovement _player;

    public EnemyTypeEnum EnemyType { get { return _enemyType; } }
    public float AttackValue { get { return _attackValue; } }

    protected void SetPlayer()
    {
        _player = GameManager.Instance.Player;
    }

    public void ApplyDamage(float value)
    {
        _currentHP -= value;
    }

    protected void ChangeState(StateEnum next)
    {
        _currentState = next;

        switch (next)
        {
            case StateEnum.None:
                {

                }
                break;
            case StateEnum.Move:
                {

                }
                break;
            case StateEnum.Dead:
                {

                }
                break;
        }
    }

    protected void UpdateState()
    {
        switch (_currentState)
        {
            case StateEnum.None:
                {

                }
                break;
            case StateEnum.Move:
                {
                    if (_currentHP <= 0)
                    {
                        ChangeState(StateEnum.Dead);
                    }

                    if (_stateManager.IsEnd)
                    {
                        SelectActionState();
                    }
                    _stateManager.UpdateState();
                }
                break;
            case StateEnum.Dead:
                {

                }
                break;
        }
    }

    protected virtual void SelectActionState()
    {
        
    }

    protected virtual void DefineState()
    {
        _stateManager.DefineState(ActionStateEnum.Idle, OnStateIdleEnter, OnStateIdleUpdate, OnStateIdleExit);
        _stateManager.DefineState(ActionStateEnum.Move, OnStateMoveEnter, OnStateMoveUpdate, OnStateMoveExit);
        _stateManager.DefineState(ActionStateEnum.Turn, OnStateTurnEnter, OnStateTurnUpdate, OnStateTurnExit);
        _stateManager.DefineState(ActionStateEnum.Chase, OnStateChaseEnter, OnStateChaseUpdate, OnStateChaseExit);
        _stateManager.DefineState(ActionStateEnum.Escape, OnStateEscapeEnter, OnStateEscapeUpdate, OnStateEscapeExit);
        _stateManager.DefineState(ActionStateEnum.Attack_01, OnStateAttack01Enter, OnStateAttack01Update, OnStateAttack01Exit);
        _stateManager.DefineState(ActionStateEnum.Attack_02, OnStateAttack02Enter, OnStateAttack02Update, OnStateAttack02Exit);
    }

    protected virtual void OnStateIdleEnter()
    {

    }
    protected virtual bool OnStateIdleUpdate()
    {
        return true;
    }
    protected virtual void OnStateIdleExit()
    {

    }
    protected virtual void OnStateMoveEnter()
    {
        
    }
    protected virtual bool OnStateMoveUpdate()
    {
        return true;
    }
    protected virtual void OnStateMoveExit()
    {
        
    }
    protected virtual void OnStateTurnEnter()
    {
        _turnTimer.ResetTimer(_turnTime);
        _turnRate = 0;

        _targetRotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * transform.rotation;
    }
    protected virtual bool OnStateTurnUpdate()
    {
        _turnRate = Mathf.Clamp01(_turnTimer.ElapsedTime / _turnTime);
        transform.localRotation = Quaternion.Lerp(transform.rotation, _targetRotation, _turnRate);

        _turnTimer.Update();

        return _turnTimer.IsTimeUp;
    }
    protected virtual void OnStateTurnExit()
    {
        
    }
    protected virtual void OnStateChaseEnter()
    {

    }
    protected virtual bool OnStateChaseUpdate()
    {
        return true;
    }
    protected virtual void OnStateChaseExit()
    {

    }
    protected virtual void OnStateEscapeEnter()
    {

    }
    protected virtual bool OnStateEscapeUpdate()
    {
        return true;
    }
    protected virtual void OnStateEscapeExit()
    {

    }
    protected virtual void OnStateAttack01Enter()
    {

    }
    protected virtual bool OnStateAttack01Update()
    {
        return true;
    }
    protected virtual void OnStateAttack01Exit()
    {

    }
    protected virtual void OnStateAttack02Enter()
    {

    }
    protected virtual bool OnStateAttack02Update()
    {
        return true;
    }
    protected virtual void OnStateAttack02Exit()
    {

    }
}
