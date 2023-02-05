using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CausticBase : MonoBehaviour
{
    private SpriteRenderer sr;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color -= new Color(0f, 0f, 0f, 1f);
        image = GetComponent<Image>();
        image.color = Color.white;
        image.color -= new Color(0f, 0f, 0f, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        sr.color -= new Color(0.0f, 0.0f, 0.0f, 0.1f) * Time.deltaTime;
        if (sr.color.a < 0.5f) Destroy(gameObject);
    }


}
