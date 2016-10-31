using UnityEngine;
using System.Collections;
using System;

abstract public class EnemyMovement : MonoBehaviour, IEnemyMovement
{

    protected NavMeshAgent agent; 
    private Vector3 target; //the thing I'm trying to get to.
    public float moveSpeed = 10f; //how fast the enemy can move
    public float turnSpeed = 10f; //how fast they can turn
    public float attackRange = 10f; //how close the enemy gets before they can attack

    public event MovedInRange inRange; //Delegate to respond to when the enemy is in range of the player
    public event MovedOutRange outRange;  //Delegate to respond wo when the enemy is out of range of the player
    private bool inRangeStatus = false;

    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.angularSpeed = turnSpeed;
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update () {
        if (agent.remainingDistance <= attackRange) // Tell my delegate that I'm in range.
        {

            if ((inRange != null) && (inRangeStatus == false))
            {
                inRangeStatus = true;
                inRange(target);
            }
        } else if ((agent.remainingDistance > attackRange) && (inRangeStatus == true))
        {
            inRangeStatus = false;
            outRange();
        }
    }

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        agent.SetDestination(target);
    }

}
