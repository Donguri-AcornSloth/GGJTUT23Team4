using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Player;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum StateEnum
    {
        StartMenu,
        Play,
        Clear,
        GameOver
    }
    
    private static GameManager _instance;
    private StateEnum _currentState;
    
    [SerializeField]
    private PlayerMovement _player = null;
    [SerializeField]
    private EnemyGenerator _enemyGenerator = null;

    public static GameManager Instance { get { return _instance; } }
    public StateEnum CurrentState { get { return _currentState; } }
    public PlayerMovement Player { get { return _player; } }
    public EnemyGenerator EnemyGenerator { get { return _enemyGenerator; } }

    public UnityEvent<StateEnum> OnStateChanged { get; } = new();

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this);
        }

        _instance = this;

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerEvolution.Instance.OnDead.AddListener(SetGameOver);
        ChangeState(StateEnum.StartMenu);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    public void ChangeState(StateEnum nextState)
    {
        Debug.Log("�Q�[�����[�h��" + nextState + "�ɕς��܂���");
        _currentState = nextState;

        //�J�ڂ����Ƃ��A�ŏ��̈�񂾂��Ă΂�鏈��
        switch (_currentState)
        {
            case StateEnum.StartMenu:
                {
                    //�Ƃ肠����������Play�Ɉڂ�悤��
                    // ChangeState(StateEnum.Play);
                }
                break;
            case StateEnum.Play:
                {
                    Initialize();
                }
                break;
            case StateEnum.Clear:
                {

                }
                break;
            case StateEnum.GameOver:
                {

                }
                break;
        }
        
        OnStateChanged?.Invoke(nextState);
    }
    void UpdateState()
    {
        //���̏�Ԓ������ƌĂ΂�鏈��
        switch (_currentState)
        {
            case StateEnum.StartMenu:
                {
                    if (Input.GetKeyDown(KeyCode.N))
                        ChangeState(StateEnum.Play);
                }
                break;
            case StateEnum.Play:
                {

                }
                break;
            case StateEnum.Clear:
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        ChangeState(StateEnum.StartMenu);
                }
                break;
            case StateEnum.GameOver:
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        ChangeState(StateEnum.StartMenu);
                }
                break;
        }
    }

    public void SetGameOver()
    {
        ChangeState(StateEnum.GameOver);
    }

    /// <summary>
    /// IInitialize���p�������S�ẴI�u�W�F�N�g������������
    /// </summary>
    private void Initialize()
    {
        List<IInitialize> initializes = GameObjectExtensions.FindObjectOfInterfaces<IInitialize>().ToList();
        foreach(IInitialize i in initializes)
        {
            i.Initialize();
        }
    }
}
