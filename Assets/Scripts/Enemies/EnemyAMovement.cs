using UnityEngine;
using System.Collections;

public class EnemyAMovement : MonoBehaviour, IEnemyMovement {

    private NavMeshAgent agent;
    private Vector3 target;
    public float moveSpeed = 10f; //how fast the enemy can move
    public float turnSpeed = 360f; //how fast they can turn
    public float closeSpeed = 20f; //this enemy charges when they get close enough
    public float chargeRange = 30f; //how close the enemy gets before charge takes over

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.angularSpeed = turnSpeed;
        agent.speed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        //if (agent.remainingDistance <= oooo
          //  \? 
	}

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        agent.SetDestination(target);
    }


}
