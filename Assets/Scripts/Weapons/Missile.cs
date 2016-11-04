using UnityEngine;
using System.Collections;

public class Missile : Projectile {
	NavMeshAgent agent;
	public float missileTurningSpeed;
	public float missileAcceleration;
	public float explosionScale;
	public float explosionLength;
	private bool explode = false;
	private float explodeInterval;

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
		if (explode == true) {
			//what is my current scale?
			if (transform.localScale.x < explosionScale) {
				transform.localScale = transform.localScale + (new Vector3(explodeInterval, explodeInterval, explodeInterval) * Time.deltaTime);
			} else {
				Destroy(gameObject);
			}
			//
		}
	}

	public override void FireAtTarget(GameObject newTarget) {
		target = newTarget;
		StartCoroutine(EndOfLife());
	}

	public override void FireAtTarget(Vector3 newTarget)
	{
		agent.SetDestination(newTarget);
		StartCoroutine(EndOfLife());
	}
	
	// Update is called once per frame

	private IEnumerator EndOfLife() {
		yield return new WaitForSeconds(lifeTime);
		explode = true;
	
		//explode interval is max scale / explode length
		explodeInterval = explosionScale / explosionLength;

		//Destroy(gameObject);

	}


}
