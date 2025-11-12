using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   
using UnityEngine.UI;

public class Distortion : MonoBehaviour
{
    public int moveAmount = 5;
    public int moveAmount2 = -5;

    public int health = 4;

    private Animator anim;

    public GameObject retryPopup;
    public Button retryButton;

    private bool isDead = false;

    public AudioSource babycry;
    public AudioClip clip;

    // private bool hasPlayedAnimation = false; 


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        anim = GetComponent<Animator>();

        if (retryPopup != null)
            retryPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up * moveAmount * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= Vector3.down * moveAmount2 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.position += Vector3.right * moveAmount * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.position -= Vector3.left * moveAmount2 * Time.deltaTime;
        }
    }

     public void PlayerHeath()
    {
        if (isDead) return;

        //if (hasPlayedAnimation)
        //{
        //    return;
        //}

        health -= 1;
  
        Debug.Log("Current Health: " + health);

        babycry.PlayOneShot(clip);
        anim.SetTrigger("appleT");

       // hasPlayedAnimation = true;

        if (health <= 0f)
        {
            isDead = true;
            //Debug.Log("youDied");
            Time.timeScale = 0f;
            retryPopup.SetActive(true);
        }
    }

    public void ShowRetryButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

