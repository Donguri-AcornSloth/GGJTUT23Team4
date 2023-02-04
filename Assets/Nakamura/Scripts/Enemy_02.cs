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
    [SerializeField]
    private float _turnSpeed = 1;
    [SerializeField]
    private float _chaseSpeed = 2;
    [SerializeField]
    private float _chaseTurnSpeed = 1;
    [SerializeField]
    private GameObject _sprite;

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
        if(InCircle(_player.gameObject.transform.position, _raderRadius))
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
        //_stateManager.AddState(ActionStateEnum.Turn);
        _stateManager.AddState(ActionStateEnum.Move);
    }
    protected override void OnStateMoveEnter()
    {
        _moveTimer.ResetTimer(_moveTime);
        float x = Random.Range(-1, 1);
        float y = Random.Range(-1, 1);
        _moveDirection = new Vector2(x, y);
        Debug.Log(_moveDirection);
        _moveDirection.Normalize();
        if(_moveDirection.x > 0)
        {
            Debug.Log("右");
            _sprite.transform.Rotate(0, 180, 0);
        }
        else
        {
            Debug.Log("左");
            _sprite.transform.Rotate(0, 0, 0);
        }
    }
    protected override bool OnStateMoveUpdate()
    {
        _rigidbody.velocity = _moveDirection * _moveSpeed;

        _moveTimer.Update();

        return _moveTimer.IsTimeUp;
    }
    protected override bool OnStateChaseUpdate()
    {
        //これをTurnUpdateに書くとプレイヤーの方向を向き続ける
        /**
        var turnDirection = _player.transform.position - transform.position;
        turnDirection.Normalize();
        Quaternion quaternion = Quaternion.LookRotation(turnDirection, Vector3.forward);
        var offsetRotation = Quaternion.FromToRotation(Vector3.up, Vector3.forward);
        _turnRate = Mathf.Clamp01(_turnTimer.ElapsedTime / _turnTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion * offsetRotation, _turnRate);
        **/
        /**
        var turnDirection = _player.transform.position - transform.position;
        turnDirection.z = 0;

        Quaternion quaternion = Quaternion.LookRotation(turnDirection, Vector3.forward);
        var offsetRotation = Quaternion.FromToRotation(Vector3.up, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion * offsetRotation, _chaseTurnSpeed);

        transform.position += transform.up * _chaseSpeed * Time.deltaTime;
        **/
        return InCircle(_player.gameObject.transform.position, _raderRadius);
    }
}
