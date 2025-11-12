using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBaby : MonoBehaviour
{
    public bool PressingKeys = false;

    public float NeedToPushAmount = 15f;

    public float mashWindow = 0.2f;     
    public float mashCooldown = 0.25f;

    //----------
    public float distance = 0.1f;
    public float speed = 10f;
    public float duration = 0.5f;

    public Animator xpush;
    public Animator ypush;
    public Animator belly;
    public Animator babyExpldoe;
    public ParticleSystem push;
    public ParticleSystem pop;

    public Wiggling wiggle;

    public AudioSource babycry;
    public AudioSource popBabe;
    public AudioSource grunt;

    private Vector3 startPos;

    private bool canMash = true;
    private bool aPressed, lPressed;
    private bool dPressed, jPressed;
    private float aTime, lTime, dTime, jTime;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { aPressed = true; aTime = Time.time; }
        if (Input.GetKeyDown(KeyCode.L)) { lPressed = true; lTime = Time.time; }

        if (Input.GetKeyDown(KeyCode.D)) { dPressed = true; dTime = Time.time; }
        if (Input.GetKeyDown(KeyCode.J)) { jPressed = true; jTime = Time.time; }

   
        if (aPressed && lPressed && canMash)
        {
            if (Mathf.Abs(aTime - lTime) <= mashWindow)
                StartCoroutine(HandleMash("out"));
            aPressed = lPressed = false; 
        }

        if (dPressed && jPressed && canMash)
        {
            if (Mathf.Abs(dTime - jTime) <= mashWindow)
                StartCoroutine(HandleMash("in"));
            dPressed = jPressed = false;
        }


        IEnumerator HandleMash(string direction)
        {
            canMash = false;

            if (direction == "out")
            {
                if (grunt) grunt.Play();
                if (xpush) xpush.SetTrigger("push");
                if (belly) belly.SetTrigger("push");
                if (wiggle) wiggle.StartWiggleX();
                push.Play();
            }
            else if (direction == "in");
            {
                if(grunt) grunt.Play();
                if (ypush) ypush.SetTrigger("pushY");
                if (belly) belly.SetTrigger("push");
                if (wiggle) wiggle.StartWiggleY();
                push.Play();
            }

            NeedToPushAmount -= 1f;
            transform.position = startPos;

            if (NeedToPushAmount <= 0f)
                PushedOutBaby();

            yield return new WaitForSeconds(mashCooldown);
            canMash = true;
        }

        void PushedOutBaby()
        {
            if (popBabe)
                popBabe.Play();
            pop.Play();
            if (babyExpldoe) babyExpldoe.SetTrigger("babyOut");
            if (belly) belly.SetTrigger("push");
            if (babycry)
                babycry.Play();

          
        }
    } }
