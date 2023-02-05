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
    private float _chaseSpeed = 2;
    [SerializeField]
    private float _chaseTurnSpeed = 1;
    [SerializeField]
    private GameObject _sprite;

    private Timer _moveTimer = new Timer();
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
        if(InCircle(_player.gameObject.transform.position, _raderRadius))
        {
            if (_stateManager.CurrentStateType == ActionStateEnum.Chase) return;

            _targetObj = _player.gameObject;
            _stateManager.ForceStop();
            _stateManager.AddState(ActionStateEnum.Chase);
        }

        DeathspownTimerUpdate();
        UpdateState();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_stateManager.CurrentStateType == ActionStateEnum.Chase) return;

        _targetObj = other.gameObject;
        _stateManager.ForceStop();
        _stateManager.AddState(ActionStateEnum.Chase);
    }

    protected override void SelectActionState()
    {
        _stateManager.AddState(ActionStateEnum.Move);
    }
    protected override void OnStateMoveEnter()
    {
        _moveTimer.ResetTimer(_moveTime);
        _moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _moveDirection.Normalize();
        if(_moveDirection.x >= 0)
        {
            Vector3 scale = _sprite.transform.localScale;
            scale.x = -1.5f;
            _sprite.transform.localScale = scale;
        }
        else
        {
            Vector3 scale = _sprite.transform.localScale;
            scale.x = 1.5f;
            _sprite.transform.localScale = scale;
        }
    }
    protected override bool OnStateMoveUpdate()
    {
        _rigidbody.velocity = _moveDirection * _moveSpeed;

        _moveTimer.Update();

        return _moveTimer.IsTimeUp;
    }
    protected override void OnStateIdleExit()
    {
        _rigidbody.velocity = Vector2.zero;
    }
    protected override bool OnStateChaseUpdate()
    {
        //‚±‚ê‚ðTurnUpdate‚É‘‚­‚ÆƒvƒŒƒCƒ„[‚Ì•ûŒü‚ðŒü‚«‘±‚¯‚é
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
        _moveDirection = _targetObj.transform.position - transform.position;
        _moveDirection.Normalize();
        if (_moveDirection.x >= 0)
        {
            Vector3 scale = _sprite.transform.localScale;
            scale.x = -1.5f;
            _sprite.transform.localScale = scale;
        }
        else
        {
            Vector3 scale = _sprite.transform.localScale;
            scale.x = 1.5f;
            _sprite.transform.localScale = scale;
        }
        _rigidbody.velocity = _moveDirection * _chaseSpeed;

        return InCircle(_targetObj.transform.position, _raderRadius);
    }
}
