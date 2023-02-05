using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTrigger : MonoBehaviour
{
    public string _targetTagName = "Herbivore";
    public UnityEvent<GameObject> OnFindEnemy = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.gameObject.CompareTag(_targetTagName))
        {
            OnFindEnemy.Invoke(other.gameObject);
        }
    }
}
