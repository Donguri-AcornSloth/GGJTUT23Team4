using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    /**
    [SerializeField]
    private PlayerController _player = null;
    **/

    private static GameManager Instance { get { return _instance; } }
    public StateEnum CurrentState { get { return _currentState; } }
    /**
    public PlayerController Player { get { return _player; } }
    **/

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
        ChangeState(StateEnum.StartMenu);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    void ChangeState(StateEnum nextState)
    {
        _currentState = nextState;

        //遷移したとき、最初の一回だけ呼ばれる処理
        switch (_currentState)
        {
            case StateEnum.StartMenu:
                {

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
    }
    void UpdateState()
    {
        //その状態中ずっと呼ばれる処理
        switch (_currentState)
        {
            case StateEnum.StartMenu:
                {

                }
                break;
            case StateEnum.Play:
                {

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
    }

    /// <summary>
    /// IInitializeを継承した全てのオブジェクトを初期化する
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
