using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public Camera cam;
    bool holding;

    void Awake() { if (!cam) cam = Camera.main; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) holding = true;
        if (Input.GetMouseButtonUp(0)) holding = false;

        if (holding)
        {
            Vector3 m = cam.ScreenToWorldPoint(Input.mousePosition);
            m.z = 0f;
            transform.position = m;
        }
    }
}
