using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBaby : MonoBehaviour
{
    public bool PressingKeys = false;

    public float PushTimer = 60f;

    public float PushCountdown;

   

    //----------
    public float distance = 0.1f;
    public float speed = 10f;
    public float duration = 0.5f;

    public Wiggling wiggle;

  
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("out");

            //PushTheBaby();
            wiggle.StartWiggle();
            
        }

        if (Input.GetKeyDown(KeyCode.D)&& Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("In");
        }
    }


 
//    void PushTheBaby()
//{
    

//}
}
