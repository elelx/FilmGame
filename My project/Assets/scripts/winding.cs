using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winding : MonoBehaviour
{
    public Animator camShake;
    public Animator lightFlicker;
    public Animator photostrip;

    [Header("Photo strip state names")]
    public string forwardState = "Photo_Forward";
    public string reverseState = "GoBack";

    [Header("Input")]
    public float deadZone = 0.02f;   // tiny jitter filter

    Camera cam;
    bool dragging;

    void Awake()
    {
        cam = Camera.main;
        SetTurning(false);
       
        if (photostrip) photostrip.Play(forwardState, 0, 0f);
        if (photostrip) photostrip.speed = 1f;
    }

    void OnMouseDown()
    {
        dragging = true;
        SetTurning(true);
    }

    void OnMouseUp()
    {
        dragging = false;
        SetTurning(false);
        if (photostrip) { photostrip.speed = 0f; photostrip.Update(0f); }
    }

    void OnMouseDrag()
    {
        Vector3 m = cam.ScreenToWorldPoint(Input.mousePosition);
        m.z = transform.position.z;
        transform.right = (m - transform.position).normalized;

  
        float dx = Input.GetAxisRaw("Mouse X");

        if (Mathf.Abs(dx) <= deadZone)
        {
            if (photostrip) { photostrip.speed = 0f; photostrip.Update(0f); }
            SetTurning(false);
            return;
        }

        SetTurning(true);

        if (dx > 0f)
        {
            if (photostrip && !photostrip.GetCurrentAnimatorStateInfo(0).IsName(forwardState))
                photostrip.CrossFade(forwardState, 0.05f, 0, 0f);
            if (photostrip) photostrip.speed = 1f;
        }
        else // dx < 0
        {
            if (photostrip && !photostrip.GetCurrentAnimatorStateInfo(0).IsName(reverseState))
                photostrip.CrossFade(reverseState, 0.05f, 0, 0f);
            if (photostrip) photostrip.speed = 1f; 
        }
    }

    void SetTurning(bool v)
    {
        if (camShake) camShake.SetBool("isTurning", v);
        if (lightFlicker) lightFlicker.SetBool("isTurning", v);
    }

}
