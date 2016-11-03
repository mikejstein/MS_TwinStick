using UnityEngine;
using System.Collections;

public class ProjectileAttack : MonoBehaviour, IAttack {

	public GameObject projectile;
	public GameObject spawnPoint;
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
			rocket.GetComponent<Projectile>().FireAtTarget(target);
			lastFireTime = Time.time;
		}
	}
	
	/*
	 * Attacking a point in space
	 */
	public virtual void StartAttack(Vector3 target)
	{
		//Instantiate the projectile
		if (Time.time - lastFireTime >= coolDown)
		{
			GameObject rocket = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
			rocket.GetComponent<Projectile>().FireAtTarget(target);
			lastFireTime = Time.time;
		}
		
	}
}
