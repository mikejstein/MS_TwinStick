using UnityEngine;
using System.Collections;
using System;

/*
 * Base class for an enemy.
*/
public class Enemy : MonoBehaviour {

    private GameObject player;
    IAttack attack;
    protected IEnemyMovement movement;


    // Use this for initialization
    protected void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        attack = GetComponent<IAttack>();
        movement = GetComponent<IEnemyMovement>(); //get our movement component
		movement.SetPlayer(player);
		movement.InRange = target => attack.StartAttack(target);
		movement.OutRange = () => attack.StopAttack();
	}
	
	// Update is called once per frame
	protected void Update () {

	}

    //Start attack when I'm in range
	public void InRange(GameObject target)
    {
        //attack.StartAttack(target);
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
