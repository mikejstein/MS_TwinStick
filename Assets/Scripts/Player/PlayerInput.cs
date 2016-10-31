using UnityEngine;
using System.Collections;

/*
 * Class for handling user input. We send the data over to PlayerControl for figuring out what to do with the input.
 * This means if we need to change input schemas, I can do that cleanly
 */
public class PlayerInput : MonoBehaviour {
    /*
     * An event that is fired every time we check for input.
     * It sends the data back to whomever is subscribed to the event.
     */ 
    public delegate void InputPolled(float leftX, float leftY, float rightX, float rightY);
    public static event InputPolled inputPolled;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame.
    // We poll the left and right sticks, and then call 
	void Update () {
        float lStickX = Input.GetAxis("Horizontal");
        float lStickY = Input.GetAxis("Vertical");

        float rStickX = Input.GetAxis("Right Stick X");
        float rStickY = Input.GetAxis("Right Stick Y");

        inputPolled(lStickX, lStickY, rStickX, rStickY);
    }
}
