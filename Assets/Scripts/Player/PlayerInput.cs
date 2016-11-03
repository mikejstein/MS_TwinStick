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
		float lStickX, lStickY, rStickX = 0, rStickY = 0;

        lStickX = Input.GetAxis("Horizontal");
        lStickY = Input.GetAxis("Vertical");

		/*
		 * Input Axis are different depending on if we're in a Mac or Windows environment
		 */

		if ((Application.platform == RuntimePlatform.WindowsEditor) || (Application.platform == RuntimePlatform.WindowsPlayer)) {
			rStickX = Input.GetAxis("Right Stick X");
        	rStickY = Input.GetAxis("Right Stick Y");
		} else if ((Application.platform == RuntimePlatform.OSXEditor) || (Application.platform == RuntimePlatform.OSXPlayer)) {
			rStickX = Input.GetAxis("Mac Right Stick X");
			rStickY = Input.GetAxis("Mac Right Stick Y");
		}

        inputPolled(lStickX, lStickY, rStickX, rStickY);
    }
}
