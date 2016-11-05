using UnityEngine;
using System.Collections;

public class Jump : EnemyMovement {

    public float jumpHeight;
    public float jumpDistance;

    private bool _isJumping = false;
	private bool isJumping
	{
		get { return _isJumping; }
		set
		{
			if (value == true)
			{
				agent.enabled = false;

            }
            else
			{
				agent.enabled = true;

            }
            _isJumping = value;
		}
	}



    /*
     * What do I do if I'm inside attack range?
     */
    protected override void insideBehavior()
    {
		assignTarget(); //always make sure my target is the player location
		if (AmBehindPlayer()) { //only attack if I'm behind the player
            if (agent.isOnNavMesh) //Because this agent jumps, make sure they're on the ground before trying to touch the mesh.
            {
                agent.Stop(); //stop moving			
                InRange(player);
            }

	
		}  else {
            if (agent.isOnNavMesh)
            {
                agent.Resume(); // every frame, we restart the agent. It may get turned off in special cases.
            }

		}
        
    }

	/*
	 * What do I do if I'm outside attack range?
	 */
    protected override void outsideBehavior()
    {
        if (agent.isOnNavMesh)
        {
            agent.Resume(); // every frame, we restart the agent. It may get turned off in special cases.
        }
		assignTarget(); //always make sur emy target is the player location

    }

	/*
	 * What do I do if I'm within avoid range?
	 */ 
	protected override void avoidBehavior()
	{

		if (isJumping == false) //Only run this check if i'm not currently jumping.
		{
			if (AmBehindPlayer()) {
				agent.Stop();
				InRange(player);
			} else {

				agent.Resume(); // every frame, we restart the agent. It may get turned off in special cases.
				if (AmInFrontOfPlayer()) { 
                //Otherwise, jump!
                	Rigidbody rb = GetComponent<Rigidbody>();						
					isJumping = true; //we're about to jump, so disable the navmesh agent so I can manually add force

                	Vector3 jumpVector = CalculateJumpVector(); //get my jump vector
                	rb.AddForce(jumpVector);
					OutRange();
				}
			}
            assignTarget();
        }

		assignTarget();
	}

	/*
	 * Determines my initial jumping speed needed to hit my desired jump height
	 */
	private float CalculateJumpSpeed(float jumpHeight, float gravity) 
	{
		 
		return (2 * jumpHeight * gravity);
	}

	private Vector3 CalculateJumpVector() {
		float gravity = Physics.gravity.magnitude; //what my current gravity force is
		float jumpSpeed = CalculateJumpSpeed(jumpHeight, gravity); //get the velocity needed to jump to the height i want
		Vector3 directionToPlayer = (player.transform.position - gameObject.transform.position).normalized; //direction I should jump in
		float jumpForce = gameObject.transform.up.y * jumpSpeed; //make sure I'm always jumping up 
		return new Vector3(directionToPlayer.x * 300, jumpForce, directionToPlayer.z * 300); //combine my up jump vector and my direction vector, so I jump towards and over the player
	}
    
    private void assignTarget()
    {
		destination = player.transform.position;
        transform.LookAt(destination);
    }

	/*
	 * This enemy only attacks if it's behind the player
	 * Dot product will give us orientation : 0 is 90 degree, 1 is in front, -1 is behind
	 */

	private float DotToPlayer() {
		Vector3 playerToMe = gameObject.transform.position - player.transform.position; //get direction from player to me
		PlayerBody pb = player.GetComponentInChildren<PlayerBody>(); //Get the player body, so I can see what direction the body is looking
		Debug.DrawRay(player.transform.position, pb.GetForward(), Color.green);
		float dotProduct = Vector3.Dot(playerToMe.normalized, pb.GetForward().normalized);
		return dotProduct;
	}


	private bool AmInFrontOfPlayer() {
		if (DotToPlayer() > 0.5) {
			return true;
		} else {
			return false;
		}
	}
	private bool AmBehindPlayer() {
		if (DotToPlayer() < -0.3) //I'm in a 90 degree cone BEHIND the player
		{
			return true;
		} else {
			return false;
		}
	}
	

	public void OnCollisionEnter(Collision other)
	{
		if ((other.collider.tag == "Ground") && (isJumping)) {
			//I've just landed, I've got to disable jumping state and re-enable my agent
			isJumping = false;
		}
	}
}
