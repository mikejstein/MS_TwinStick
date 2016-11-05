using UnityEngine;
using System.Collections;
using System;

abstract public class EnemyMovement : MonoBehaviour, IEnemyMovement
{

    protected NavMeshAgent agent; 
    protected Vector3 destination; //the thing I'm trying to get to.
	protected GameObject player;

    public float moveSpeed; //how fast the enemy can move
    public float turnSpeed; //how fast they can turn
    public float attackRange; //how close the enemy gets before they can attack
    public float avoidRange; //How close the enemy gets before it needs to take evasive action

	public Action<GameObject> InRange { get; set; }
	public Action OutRange {get; set;}

    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.angularSpeed = turnSpeed;
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    protected void Update () {
        Vector3 toPlayer = player.transform.position - gameObject.transform.position; //Get the vector from me to the player
        if (toPlayer.magnitude <= avoidRange) // if I'm within avoid range of the player, get away
        {
            avoidBehavior();
        }
        else if (toPlayer.magnitude > attackRange) // if I'm outside attack range of player, move towards
        {
            outsideBehavior();
        }
        else if (toPlayer.magnitude <= attackRange) //I'm i'm within attack range, do 'inside behavior' which is often attack
        {
            insideBehavior();
        }
		SetDestination(destination);
    }
    
    /*
     * Changes my navmesh agent's target
    */
    public virtual void SetDestination(Vector3 newDestination)
    {
		destination = newDestination;
		if (agent.enabled)
        {
            agent.SetDestination(destination);
        }
    }
	

    public void ChangeSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }

	public void SetPlayer(GameObject p) {
		player = p;
	}

	protected abstract void avoidBehavior();
	protected abstract void outsideBehavior();
	protected abstract void insideBehavior();
}
