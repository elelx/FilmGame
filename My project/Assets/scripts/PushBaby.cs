using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBaby : MonoBehaviour
{
    public bool PressingKeys = false;

    public float NeedToPushAmount = 5f;

    public float PushCountdown;


    //----------
    public float distance = 0.1f;
    public float speed = 10f;
    public float duration = 0.5f;

    public Wiggling wiggle;

    public AudioSource babycry;
    public AudioClip clip;



  
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)&& Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("out");

            //PushTheBaby();
            wiggle.StartWiggleX();

            NeedToPushAmount -= 1;



        }

        if (Input.GetKeyDown(KeyCode.D)&& Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("In");
            wiggle.StartWiggleY();

            NeedToPushAmount -= 1;
        }
        if (NeedToPushAmount <= PushCountdown)
        {
            pushedOutBaby();
        }
           


    }

    void pushedOutBaby()
    {
      
        Debug.Log("uPushedoutTheBaby");
    

        babycry.PlayOneShot(clip);

    }




    //    void PushTheBaby()
    //{


    //}
}
