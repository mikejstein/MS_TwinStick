using UnityEngine;
using System.Collections;
using System;

/*
 * Class that defines a laser attack for the player
 */
public class PlayerLaserAttack : MonoBehaviour, IPlayerAttack, PowerUpResponder {
    public LineRenderer lineRenderer;
    public float castRadius = 0.1f; //how wide a beam we're shooting
    public float powerTime = 3; //how long the power up impacts the laser

    // Use this for initialization
    void Start() {
    }


    public void Attack(Vector3 InDirection)
    {
        RaycastHit hit;
        
        //Draw a line where I'm casting, so the player can see the laser
        DrawWeapon(InDirection);

        // Instead of raycast, I'm using a spherecast for hit detection. This way I can change the thickness of my beam for a power up.
        // I'm going to cat out for 15 units. If it was infinite, a player could just sit in the middle and sweep around.

        if (Physics.SphereCast(gameObject.transform.position, castRadius, InDirection, out hit, 15f))
        //if (Physics.Raycast(gameObject.transform.position, InDirection, out hit))
        {
            if (hit.collider.tag == "Enemy") { //If I hit an enemy, destroy the enemy and increment my score
				GameManager.IncrementScore();
				Destroy(hit.collider.gameObject);
			}
        }
    }

    public void EndAttack()
    {
        if (lineRenderer.enabled) // hide the line rendered when the player is not attacking
        {
            lineRenderer.enabled = false;
        }
    }

    private void DrawWeapon(Vector3 direction)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetWidth(castRadius, castRadius); //make sure the line renderer is showing my power up, if necessary
        lineRenderer.SetPosition(0, gameObject.transform.position); //draw from my position...
        lineRenderer.SetPosition(1, gameObject.transform.position + direction * 15); //in the direction i'm shooting.
    }

    /*
     * The player power up boosts the radius of their weapon.
     * It runs for 3 seconds, and then sets it's radius back to normal
     */
    public void ExecutePowerUp()
    {
        float oldRadius = castRadius;
        castRadius = 5;
        StartCoroutine(EndPower(oldRadius));
    }
    
    IEnumerator EndPower(float newRadius)
    {
        yield return new WaitForSeconds(powerTime);
        castRadius = newRadius;
    }
}


