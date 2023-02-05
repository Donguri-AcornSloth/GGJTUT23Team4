using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class chaseObject : MonoBehaviour
{
    [SerializeField] private GameObject Obj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 objPos = Obj.transform.position;
        this.transform.position = objPos;
    }
}
