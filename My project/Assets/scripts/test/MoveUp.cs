using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public int moveAmount = 1;
    public int moveAmount2 = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up * moveAmount * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= Vector3.down * moveAmount2 * Time.deltaTime;
        }
    }

  

}


