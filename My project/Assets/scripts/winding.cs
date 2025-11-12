using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winding : MonoBehaviour
{
    Camera cam;

    void Awake() { cam = Camera.main; }

    void OnMouseDrag()
    {
        Vector3 m = cam.ScreenToWorldPoint(Input.mousePosition);
        m.z = transform.position.z;     // keep same z depth

        // rotate to face the mouse
        transform.right = (m - transform.position).normalized;
    }

   
}
