using UnityEngine;
using System.Collections;

public class Ranged : EnemyMovement {
    Vector3 avoidLocation;



    /*
     * Smooths out looking at a target, so we aren't instantaniously rotating
     */
    private void LerpLookAt(Vector3 destination)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(destination - transform.position), turnSpeed * Time.deltaTime);

    }

    protected override void avoidBehavior()
    {
        Vector3 toPlayer = player.transform.position - transform.position; //Get the direction to my player
        avoidLocation = transform.position + toPlayer * -1 * avoidRange; // Find my 'run to' point
        NavMeshHit hit;
        NavMesh.SamplePosition(avoidLocation, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable")); //have the navmesh find the closest point on the navmesh that matches my moveto vector.
        destination = avoidLocation; //set my target to my 'run to' points
        LerpLookAt(destination); //make sure I'm looking at my 'run to' point
		OutRange();
    }

    protected override void outsideBehavior()
    {
        destination = player.transform.position;
        LerpLookAt(destination); //look at my target
		OutRange();
    }

    protected override void insideBehavior()
    {
        destination = transform.position; //my target is my location - effectively, stop moving around
        LerpLookAt(player.transform.position); //look at the player
      
        //check to see if target is within a cone of visibility
        // Hooray for linear algebra - dot product will tell the orientiation of player to me : 0 is 90 degree, 1 is in front, -1 is behind
        // So, as long as I'm greater than 0.5, i'm in the right spot.
        Vector3 toPlayer = player.transform.position - transform.position; //Get the direction to my plyaer
		float dotProduct = Vector3.Dot(toPlayer.normalized, transform.forward.normalized);
        if (dotProduct > 0.5)
        {
			InRange(player);
        }
    }
}
