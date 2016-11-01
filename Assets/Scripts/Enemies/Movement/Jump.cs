using UnityEngine;
using System.Collections;

public class Jump : EnemyMovement {
    Vector3 jumpLocation;
    public float jumpForce;
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
    // Use this for initialization
    protected override void insideBehavior()
    {
        assignTarget();
    }

    protected override void outsideBehavior()
    {
        Vector3 toPlayer = playerLocation - gameObject.transform.position; //Direction to my player
        assignTarget();

    }

    protected override void avoidBehavior()
    {
        if (isJumping == false)
        {
            Debug.Log("ADDING A FROCE");
            Rigidbody rb = GetComponent<Rigidbody>();

            assignTarget();
            Vector3 playerVelocity = rb.velocity;
            Debug.Log(playerVelocity);
            Vector3 toPlayer = (playerLocation - gameObject.transform.position).normalized; //Direction to my player
            isJumping = true; //we're about to jump, which disables the navmesh agent
            GetComponent<Rigidbody>().AddForce(toPlayer.x * moveSpeed * 2, jumpForce, toPlayer.z * moveSpeed * 2);
            CallOutRange(); //I don't want to shoot, so tell my range delegate that I'm out of range
            Debug.Log("IS JUMPING IS " + isJumping);
        }

    }

    private void assignTarget()
    {
        target = playerLocation; //this enemy ALWAYS targets the player, no matter what
    }
}
