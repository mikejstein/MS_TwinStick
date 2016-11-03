using UnityEngine;
using System.Collections;
using System;

abstract public class EnemyMovement : MonoBehaviour, IEnemyMovement
{

    protected NavMeshAgent agent; 
    protected Vector3 target; //the thing I'm trying to get to.
    protected Vector3 playerLocation; //the location of the player. This is updated every frame by Enemy.cs

    public float moveSpeed; //how fast the enemy can move
    public float turnSpeed; //how fast they can turn
    public float attackRange; //how close the enemy gets before they can attack
    public float avoidRange; //How close the enemy gets before it needs to take evasive action

    public event MovedInRange inRange; //Delegate to respond to when the enemy is in range of the player
    public event MovedOutRange outRange;  //Delegate to respond wo when the enemy is out of range of the player


    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.angularSpeed = turnSpeed;
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    protected void Update () {
        Vector3 toPlayer = playerLocation - gameObject.transform.position; //Get the vector from me to the player
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
        SetTarget(target); //Any of the above behaviors may change my target, which means I need to update my navmesh target

    }
    protected abstract void avoidBehavior();
    protected abstract void outsideBehavior();
    protected abstract void insideBehavior();

    /*
     * Updates the move component with the player's location
     */
    public void SetPlayerLocation(Vector3 newPlayerLocation)
    {
        playerLocation = newPlayerLocation;
    }

    /*
     * Changes my navmesh agent's target
    */
    public virtual void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        if (agent.enabled)
        {
            agent.SetDestination(target);
        }
    }

    protected virtual void CallInRange(Vector3 target)
    {
        if (inRange != null)
        {
            inRange(target);
        }
    }

    protected virtual void CallOutRange()
    {
        if (outRange != null)
        {
            outRange();
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }
}
