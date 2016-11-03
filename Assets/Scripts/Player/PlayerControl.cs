using UnityEngine;
using System.Collections;

/*
 * Class that determines how the player object responds to input.
 */
public class PlayerControl : MonoBehaviour {

    public float moveSpeed = 10; // How fast we move around
    private PlayerBody body; //the mesh representation of the player.
    private Rigidbody rb; //our rigid body

    private IPlayerAttack attackComponent;

	// Use this for initialization
	void Start () {
        PlayerInput.inputPolled += MoveAndShoot; //make sure we're subscribed to the event out of Player Input
        body = GetComponentInChildren<PlayerBody>();
        rb = GetComponent<Rigidbody>(); // Connect our rigidbody variable to our rigidbody component
        attackComponent = GetComponent<IPlayerAttack>(); //cache a reference to our attack script
	}
	
	

    private void MoveAndShoot(float leftX, float leftY, float rightX, float rightY)
    {
        /* Calculate our movement vector.
         * We first create a Vector3 from our lefX and leftY parameteres.
         * Then we convert that from local space to world space.
         * Then we multiplly that by our movement units and time since we last ran this function
         */
        Vector3 movement = transform.TransformDirection(new Vector3(leftX, 0, leftY) * moveSpeed * Time.deltaTime);
        if (movement.magnitude != 0)
        {
            body.SetRotation(Quaternion.LookRotation(movement));
        }
        rb.MovePosition(transform.position + movement);

        /* Calculate our shoot vector.
         * Similar to the above calcuation, we're turning the axis on the right stick into a direction.
         * We only tell the attack componenet to fire if the right stick is actually doing something (if the direction magnitue is > 0)
         */
        Vector3 shotDirection = transform.TransformDirection(new Vector3(rightX, 0, rightY * -1));
        if (attackComponent != null)
        {
            if (shotDirection.sqrMagnitude > 0)
            {
                attackComponent.Attack(shotDirection);
            } else
            {
                attackComponent.EndAttack();
            }
        }
    }


}
