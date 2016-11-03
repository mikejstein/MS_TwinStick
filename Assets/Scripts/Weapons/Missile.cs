using UnityEngine;
using System.Collections;

public class Missile : Projectile {
	NavMeshAgent agent;
	public float missileTurningSpeed;
	public float missileAcceleration;

	private GameObject target; //What I'm targeting



	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.speed = speed;
		agent.angularSpeed = missileTurningSpeed;
		agent.acceleration = missileAcceleration;
	}

	void Update () {
		if (target != null) {
			agent.SetDestination(target.transform.position);
		}
	}


	public override void FireAtTarget(Vector3 newTarget)
	{
		agent.SetDestination(newTarget);
		StartCoroutine(EndOfLife());
	}

	public override void FireAtTarget (GameObject newTarget)
	{
		target = newTarget;
		StartCoroutine(EndOfLife());
	}

	// Update is called once per frame

	private IEnumerator EndOfLife() {
		yield return new WaitForSeconds(lifeTime);
		Debug.Log("BOOM GOES THE ROCKET!");
		Destroy(gameObject);

	}

}
