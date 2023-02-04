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
    protected bool _viewRaderCircle = false;
    [SerializeField]
    protected float _raderRadius;
    [SerializeField]
    protected float _turnTime = 3f;
    [SerializeField]
    protected float _idleTime = 3f;

    [SerializeField]
    protected Rigidbody2D _rigidbody = null;

    protected StateEnum _currentState;
    protected StateManager<ActionStateEnum> _stateManager = new StateManager<ActionStateEnum>();
    protected Timer _idleTimer = new Timer();
    protected Timer _turnTimer = new Timer();
    protected Vector2 _moveDirection;
    protected Quaternion _targetRotation;
    protected float _turnRate = 0;
    protected PlayerMovement _player;
    private int _spownGeneration;
    private int _id;
    private Timer _deathspownTimer = new Timer();

    public EnemyTypeEnum EnemyType { get { return _enemyType; } }
    public float AttackValue { get { return _attackValue; } }
    public int SpownGeneration { get { return _spownGeneration; } }
    public int ID { get { return _id; } }

    protected void SetPlayer()
    {
        _deathspownTimer.ResetTimer(GameManager.Instance.EnemyGenerator.DeathspownTime);
        _player = GameManager.Instance.Player;
    }

    public void ApplyDamage(float value)
    {
        _currentHP -= value;
    }

    public void SetId(int generation, int id)
    {
        _spownGeneration = generation;
        _id = id;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            _stateManager.ForceStop();
            _stateManager.AddState(ActionStateEnum.Idle);
        }
    }

    /// <summary>
    /// 感知範囲内に目標座標があるかどうか
    /// </summary>
    /// <param name="myPos"></param>
    /// <param name="targetPos"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    protected bool InCircle(Vector2 targetPos, float radius)
    {
        var sum = 0f;
        for(var i = 0; i < 2; i++)
        {
            sum += Mathf.Pow(transform.position[i] - targetPos[i], 2);
        }
        return sum <= Mathf.Pow(radius, 2f);
    }

    protected void DeathspownTimerUpdate()
    {
        if (InCircle(_player.gameObject.transform.position, GameManager.Instance.EnemyGenerator.SpownMinRange) == false)
        {
            _deathspownTimer.Update();

            if (_deathspownTimer.IsTimeUp)
            {
                GameManager.Instance.EnemyGenerator.ObjectRemove(this);
                Debug.Log("エネミーを破棄");
                Destroy(this.gameObject);
            }
        }
        else
        {
            _deathspownTimer.ResetTimer(GameManager.Instance.EnemyGenerator.DeathspownTime);
        }
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

    private void OnDrawGizmos()
    {
        if (!_viewRaderCircle) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _raderRadius);
    }

    protected virtual void OnStateIdleEnter()
    {
        Debug.Log("Enter");
        _idleTimer.ResetTimer(_idleTime);
    }
    protected virtual bool OnStateIdleUpdate()
    {
        _idleTimer.Update();

        return _idleTimer.IsTimeUp;
    }
    protected virtual void OnStateIdleExit()
    {
        Debug.Log("Exit");
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
