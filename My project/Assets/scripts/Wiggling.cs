using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggling : MonoBehaviour
{

    public float distance = 0.1f;
    public float speed = 10f;
    public float duration = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartWiggleY()
    {
        StartCoroutine(WiggleY());
    }

    public void StartWiggleX()
    {
        StartCoroutine(WiggleX());
    }


    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator WiggleY()
    {
        float time = 0;
        Vector3 startPos = transform.localPosition;

        while (time < duration)
        {
            float y = Mathf.Sin(time * speed) * distance * (1 - (time / duration));
            transform.localPosition = startPos + new Vector3(0, y, 0);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
    }

    IEnumerator WiggleX()
    {
        float time = 0;
        Vector3 startPos = transform.localPosition;

        while (time < duration)
        {
            float x = Mathf.Sin(time * speed) * distance * (1 - (time / duration));
            transform.localPosition = startPos + new Vector3(x, 0, 0);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
    }

}
