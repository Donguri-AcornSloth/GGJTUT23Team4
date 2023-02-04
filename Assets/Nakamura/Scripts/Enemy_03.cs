using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_03 : EnemyBase
{
    [SerializeField]
    private float _moveSpeed = 1;
    [SerializeField]
    private float _moveTime = 3;
    [SerializeField]
    private float _turnSpeed = 1;
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
        /**
        if (InCircle(_player.gameObject.transform.position, _raderRadius))
        {
            if (_stateManager.CurrentStateType == ActionStateEnum.Chase) return;

            _stateManager.ForceStop();
            _stateManager.AddState(ActionStateEnum.Chase);
        }
        **/

        DeathspownTimerUpdate();
        UpdateState();
    }

    protected override void SelectActionState()
    {
        _stateManager.AddState(ActionStateEnum.Idle);
        _stateManager.AddState(ActionStateEnum.Move);
    }
    protected override void OnStateMoveEnter()
    {
        _moveTimer.ResetTimer(_moveTime);
        _moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
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
}
