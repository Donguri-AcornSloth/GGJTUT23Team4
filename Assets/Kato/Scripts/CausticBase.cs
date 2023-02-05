using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticBase : MonoBehaviour
{
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        sr.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f) * Time.deltaTime;
        if (sr.color.a < 0.5f) Destroy(gameObject);
    }
}
