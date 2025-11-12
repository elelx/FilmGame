using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuttinAnim : MonoBehaviour
{

    public Animator anim;            // drag your Animator here
    public string cutBool = "IsCutting"; // Bool in your Animator
    public PressKeys mashGate;

    bool played;

    bool inCutState;

    void Awake()
    {
        if (!anim) anim = GetComponent<Animator>();
        //if (anim) anim.speed = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (played) return;
        Debug.Log("Entered cut zone: " + collision.name);


        TryPlayCut();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // keep updating while inside the collider
        TryPlayCut();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Left cut zone: " + collision.name);
        if (anim) anim.SetBool(cutBool, false); // stop anim immediately
        if (anim) anim.speed = 0f;
    }

    void TryPlayCut()
    {
        bool mouseHeld = Input.GetMouseButton(0);  // dragging?
        bool gateOK = (mashGate == null) ? true : mashGate.canCut;
        bool shouldCut = mouseHeld && gateOK;

        if (!anim) return;

        if (shouldCut)
        {
            // enter Cut state ONCE
            if (!inCutState)
            {
                anim.SetBool(cutBool, true); // triggers Idle -> Cut once
                inCutState = true;
            }
            // resume from current frame
            anim.speed = 1f;
        }
        else
        {
            // pause exactly where it is
            anim.speed = 0f;
        }
    }

    public void StopCut()
    {
        Debug.Log("Cut animation finished!");
        played = true;                // mark as done so it doesn’t restart
        if (anim) anim.SetBool(cutBool, false); // stop the animation
        var col = GetComponent<Collider2D>();
        if (col) col.enabled = false; // optional: disable collider so it can’t retrigger
    }
}
