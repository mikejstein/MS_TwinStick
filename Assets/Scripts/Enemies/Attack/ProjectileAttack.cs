using UnityEngine;
using System.Collections;

public class ProjectileAttack : MonoBehaviour, IAttack {

	public GameObject projectile;
	public float coolDown;
	protected float lastFireTime;

	// Use this for initialization
	void Start () {
		lastFireTime = Time.time - coolDown;
	}
	
	
	public void StopAttack()
	{
		
	}
	
	
	/*
     * Attacking a game object
     */
	public virtual void StartAttack(GameObject target) {
		if (Time.time - lastFireTime >= coolDown)
		{
			GameObject rocket = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

			Physics.IgnoreCollision(rocket.GetComponentInChildren<Collider>(), GetComponent<Collider>(), true);
			rocket.GetComponent<IProjectile>().FireAtTarget(target);
			lastFireTime = Time.time;
		}
	}	

}
