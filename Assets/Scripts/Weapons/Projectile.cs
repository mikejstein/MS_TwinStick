using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour, IProjectile {

	private Rigidbody rb; //My body
	public float speed; //how fast I move
	public float lifeTime; //How long I last

		
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}
	
	
	private IEnumerator EndOfLife() {
		yield return new WaitForSeconds(lifeTime);
		rb.useGravity = true;
	}

	public virtual void FireAtTarget(Vector3 newTarget) {
		Vector3 direction = (newTarget - gameObject.transform.position).normalized;
		rb.AddForce(direction * speed);
		StartCoroutine(EndOfLife());
	}

	public virtual void FireAtTarget(GameObject newTarget)
	{
		FireAtTarget(newTarget.transform.position);
	}
	
	public void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Ground")
		{
			Destroy(gameObject);
		}
		else if (collider.tag == "Player")
		{
			Debug.Log("HIT PLAYER");
			Destroy(gameObject);
		}
	}
}