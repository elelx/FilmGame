using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class win : MonoBehaviour
{

    public GameObject retryPopup;
    public Button playAgainButton;


    // Start is called before the first frame update
    void Start()
    {
        if (retryPopup != null)
            retryPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            retryPopup.SetActive(true);
        }
    }

    public void ShowRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
