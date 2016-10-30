using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed = 10; // How fast we move around
    public float turnSpeed = 50; // How fast we turn around
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        PlayerInput.inputPolled += MoveAndShoot; //make sure we're subscribed to the event out of Player Input

        rb = GetComponent<Rigidbody>(); // Connect our rigidibody variable to our rigidbody component
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void MoveAndShoot(float leftX, float leftY, float rightX, float rightY)
    {
        /* Calculate our movement vector.
         * We first create a Vector3 from our lefX and leftY parameteres.
         * Then we convert that from local space to world space.
         * Then we multiplly that by our movement units and time since we last ran this function
         */
        Vector3 movement = transform.TransformDirection(new Vector3(leftX, 0, leftY) * moveSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);

        /* Calculate our shoot vector.
         * For this, we actually 
         */
    }
}
