using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class FeedBase : MonoBehaviour
{
    [SerializeField, Tooltip("�a�̃^�C�v(��������)")]
    protected FeedType _feedType;
    [SerializeField, Tooltip("�a�̓ł̗L��")]
    protected FeedPoison _feedPoison;

    protected enum FeedType
    {
        ��, //��
        ��, //��
    }

    protected enum FeedPoison
    {
        �ł���, //�ł���
        �łȂ�, //�łȂ�
    }

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
        
    }

    public void PickUp()
    {
        Destroy(this.gameObject);
    }
}
