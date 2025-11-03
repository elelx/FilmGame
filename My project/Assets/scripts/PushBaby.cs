using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBaby : MonoBehaviour
{
    public bool PressingKeys = false;

    public float PushTimer = 60f;

    public float PushCountdown;

   

    //----------

    float duration = 1f;
    float speed = 20f;
    float distance = 2f;
    float time = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D)&& Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("pressing");

            PushTheBaby();
        }
    }


void PushTheBaby()
{
    

}
}
