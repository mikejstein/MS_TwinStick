using UnityEngine;
using System.Collections;

public class ProjectileAttack : MonoBehaviour, IAttack, PowerUpResponder {

	public GameObject projectile;
	public float coolDown;
	protected float lastFireTime;
    public float powerTime;

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

    /*
     * Boosting the size of our projectile
     */
    public void ExecutePowerUp()
    {
        Vector3 lastScale = projectile.transform.localScale;
        projectile.transform.localScale = lastScale * 10;
        StartCoroutine(EndPower(lastScale));
    }

    IEnumerator EndPower(Vector3 lastScale)
    {
        yield return new WaitForSeconds(powerTime);
        projectile.transform.localScale = lastScale;
    }

}
