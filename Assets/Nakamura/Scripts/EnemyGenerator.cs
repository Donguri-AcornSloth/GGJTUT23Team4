using Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class EnemyGenerator : MonoBehaviour, IInitialize
{
    [SerializeField]
    private List<GameObject> _firstGenerationEnemyPfList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _secondGenerationEnemyPfList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _thridGenerationEnemyPfList = new List<GameObject>();

    [SerializeField]
    private int _firstGenerationMaxEnemy = 6;
    [SerializeField]
    private int _secondGenerationMaxEnemy = 6;
    [SerializeField]
    private int _thirdGenerationMaxEnemy = 6;

    [SerializeField]
    private float _spownInterval = 10;

    [SerializeField]
    private bool _viewSpownCircle = false;
    [SerializeField]
    private float _spownMinRange = 10;
    [SerializeField]
    private float _spownMaxRange = 30;

    [SerializeField]
    private float _deathspownTime = 20;

    private List<GameObject> _firstGenerationEnemyList = new List<GameObject>();
    private List<GameObject> _secondGenerationEnemyList = new List<GameObject>();
    private List<GameObject> _thirdGenerationEnemyList = new List<GameObject>();
    private int _spownCount = 0;
    private Timer _intervalTimer = new Timer();

    public float SpownMinRange { get { return _spownMinRange; } }
    public float DeathspownTime { get { return _deathspownTime; } }

    // Start is called before the first frame update
    void Start()
    {
        _intervalTimer.ResetTimer(_spownInterval);
        PlayerEvolution.Instance.OnLevelChanged.AddListener(EvolutionEvent);
    }

    // Update is called once per frame
    void Update()
    {
        _intervalTimer.Update();

        if (_intervalTimer.IsTimeUp)
        {
            GenerateEnemy();
            _intervalTimer.ResetTimer(_spownInterval);
        }
    }

    void GenerateEnemy()
    {
        switch (PlayerEvolution.Instance.Level)
        {
            case 1:
                {
                    if(_firstGenerationEnemyList.Count != _firstGenerationMaxEnemy)
                    {
                        int n = Random.Range(0, _firstGenerationEnemyPfList.Count());
                        GameObject enemy = Instantiate(_firstGenerationEnemyPfList[n], GetRandomPos(), Quaternion.identity);
                        _spownCount++;
                        enemy.GetComponent<EnemyBase>().SetId(1, _spownCount);
                        _firstGenerationEnemyList.Add(enemy);
                    }
                }
                break;
            case 2:
                {
                    if(_secondGenerationEnemyList.Count != _secondGenerationMaxEnemy)
                    {
                        int n = Random.Range(0, _secondGenerationEnemyPfList.Count());
                        GameObject enemy = Instantiate(_secondGenerationEnemyPfList[n], GetRandomPos(), Quaternion.identity);
                        _spownCount++;
                        enemy.GetComponent<EnemyBase>().SetId(2, _spownCount);
                        _secondGenerationEnemyList.Add(enemy);
                    }
                }
                break;
            case 3:
                {
                    if(_thirdGenerationEnemyList.Count != _thirdGenerationMaxEnemy)
                    {
                        int n = Random.Range(0, _thridGenerationEnemyPfList.Count());
                        GameObject enemy = Instantiate(_thridGenerationEnemyPfList[n], GetRandomPos(), Quaternion.identity);
                        _spownCount++;
                        enemy.GetComponent<EnemyBase>().SetId(3, _spownCount);
                        _thirdGenerationEnemyList.Add(enemy);
                    }
                }
                break;
        }
    }

    private void OnDrawGizmos()
    {
        if (!_viewSpownCircle) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GameManager.Instance.Player.gameObject.transform.position, _spownMinRange);
        Gizmos.DrawWireSphere(GameManager.Instance.Player.gameObject.transform.position, _spownMaxRange);
    }

    public void ObjectRemove(EnemyBase target)
    {
        switch (target.SpownGeneration)
        {
            case 1:
                {
                    for(int i = 0; i < _firstGenerationEnemyList.Count; i++)
                    {
                        var enemy = _firstGenerationEnemyList[i].GetComponent<EnemyBase>();
                        if(target.ID == enemy.ID)
                        {
                            _firstGenerationEnemyList.RemoveAt(i);
                            return;
                        }
                    }
                }
                break;
            case 2:
                {
                    for (int i = 0; i < _secondGenerationEnemyList.Count; i++)
                    {
                        var enemy = _secondGenerationEnemyList[i].GetComponent<EnemyBase>();
                        if (target.ID == enemy.ID)
                        {
                            _secondGenerationEnemyList.RemoveAt(i);
                            return;
                        }
                    }
                }
                break;
            case 3:
                {
                    for (int i = 0; i < _thirdGenerationEnemyList.Count; i++)
                    {
                        var enemy = _thirdGenerationEnemyList[i].GetComponent<EnemyBase>();
                        if (target.ID == enemy.ID)
                        {
                            _thirdGenerationEnemyList.RemoveAt(i);
                            return;
                        }
                    }
                }
                break;
        }
    }

    public void EvolutionEvent(int level)
    {
        Debug.Log(level);
        switch (level)
        {
            case 2:
                {
                    foreach(var enemy in _firstGenerationEnemyList)
                    {
                        Destroy(enemy);
                    }
                    _firstGenerationEnemyList.Clear();
                }
                break;
            case 3:
                {
                    foreach (var enemy in _secondGenerationEnemyList)
                    {
                        Destroy(enemy);
                    }
                    _secondGenerationEnemyList.Clear();
                }
                break;
        }
    }

    private Vector3 GetRandomPos()
    {
        var angle = Random.Range(0, 360);
        var radius = Random.Range(_spownMinRange, _spownMaxRange);
        var rad = angle * Mathf.Deg2Rad;
        var px = Mathf.Cos(rad) * radius + GameManager.Instance.Player.transform.position.x;
        var py = Mathf.Sin(rad) * radius + GameManager.Instance.Player.transform.position.y;
        return new Vector3(px, py, 0);
    }

    public void Initialize()
    {
        _spownCount = 0;
        _intervalTimer.ResetTimer(_spownInterval);
        for(int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 1:
                    {
                        foreach (var enemy in _firstGenerationEnemyList)
                        {
                            Destroy(enemy.gameObject);
                        }
                        _firstGenerationEnemyList.Clear();
                    }
                    break;
                case 2:
                    {
                        foreach (var enemy in _secondGenerationEnemyList)
                        {
                            Destroy(enemy.gameObject);
                        }
                        _secondGenerationEnemyList.Clear();
                    }
                    break;
                case 3:
                    {
                        foreach (var enemy in _thirdGenerationEnemyList)
                        {
                            Destroy(enemy.gameObject);
                        }
                        _thirdGenerationEnemyList.Clear();
                    }
                    break;
            }
        }
    }
}
