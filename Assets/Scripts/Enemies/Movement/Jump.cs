using UnityEngine;
using System.Collections;

public class Jump : EnemyMovement {

    public float jumpHeight;
	private GameObject player;

    private bool _isJumping = false;
	private bool isJumping
	{
		get { return _isJumping; }
		set
		{
			if (value == true)
			{
				agent.enabled = false;
			} else
			{
				agent.enabled = true;
			}
			_isJumping = value;
		}
	}


	new void Start() {
		base.Start ();
		player = GameObject.FindWithTag("Player");
	}
	

    /*
     * What do I do if I'm inside attack range?
     */ 
    protected override void insideBehavior()
    {
		assignTarget(); //always make sure my target is the player location
		if (AmBehindPlayer()) { //only attack if I'm behind the player
			CallInRange(target);
		}
        
    }

	/*
	 * What do I do if I'm outside attack range?
	 */
    protected override void outsideBehavior()
    {
		assignTarget(); //always make sur emy target is the player location

    }

	/*
	 * What do I do if I'm within avoid range?
	 */ 
	protected override void avoidBehavior()
	{
		assignTarget();
		if (isJumping == false) //Only run this check if i'm not currenlty jumping.
		{
			if (AmBehindPlayer()) {
				CallInRange(target); //If I'm behind the player, attack!
			} else {
				//Otherwise, jump!
				Rigidbody rb = GetComponent<Rigidbody>();						
				isJumping = true; //we're about to jump, so disable the navmesh agent so I can manually add force
				Vector3 jumpVector = CalculateJumpVector(); //get my jump vector
				rb.AddForce(jumpVector);
				CallOutRange(); //I don't want to shoot, so tell my range delegate that I'm out of range
			}
			
		}
		
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
		Vector3 directionToPlayer = playerLocation - gameObject.transform.position; //direction I should jump in
		float jumpForce = gameObject.transform.up.y * jumpSpeed; //make sure I'm always jumping up 
		return new Vector3(directionToPlayer.x * 55, jumpForce, directionToPlayer.z * 55); //combine my up jump vector and my direction vector, so I jump towards and over the player
	}
    
    private void assignTarget()
    {
        target = playerLocation; //this enemy ALWAYS targets the player, no matter what
    }

	/*
	 * This enemy only attacks if it's behind the player
	 * Dot product will give us orientation : 0 is 90 degree, 1 is in front, -1 is behind
	 */
	private bool AmBehindPlayer() {
		Vector3 playerToMe = gameObject.transform.position - playerLocation; //get direction from player to me
		float dotProduct = Vector3.Dot(playerToMe.normalized, player.transform.forward.normalized);
		if (dotProduct < -0.5) //I'm in a 90 degree cone BEHIND the player
		{
			return false;
		} else {
			return true;
		}
	}
	

	public void OnCollisionEnter(Collision other)
	{
		if (isJumping) {
			//I've just landed, I've got to disable jumping state and re-enable my agent
			isJumping = false;
		}
	}
}
