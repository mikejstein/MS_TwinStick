using UnityEngine;
using System.Collections;
using System;

/*
 * Abstract base class for an enemy.
*/
public class Enemy : MonoBehaviour {

    private GameObject player;
    IAttack attack;
    protected IEnemyMovement movement;
    protected Action<Vector3> inRange;

    // Use this for initialization
    protected void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        attack = GetComponent<IAttack>();
        movement = GetComponent<IEnemyMovement>(); //get our movement component
        movement.inRange += InRange; //connect our range delegates from our movement component to our range responders
        movement.outRange += OutRange;
        movement.SetTarget(player.transform.position); //set the target of our movement scripts to teh player's current position
	}
	
	// Update is called once per frame
	protected void Update () {
        if (movement != null)
        {
            movement.SetPlayerLocation(player.transform.position); //every enemy will always know where the player is.
        }
	}

    //Start attack when I'm in range
    public void InRange(Vector3 target)
    {
        attack.StartAttack(target);
        // tell my attack module to attack

    }

    //Stop attack when I'm out of range
    public void OutRange()
    {
        if (attack != null)
        {
            attack.StopAttack();
        }
    }
}
