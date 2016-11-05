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


	public virtual void FireAtTarget(GameObject newTarget) {
		Vector3 direction = (newTarget.transform.position - gameObject.transform.position).normalized;
		rb.AddForce(direction * speed);
		StartCoroutine(EndOfLife());
	}
	

	public virtual void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Ground")
		{
			Destroy(gameObject);
		}
		else if (collider.tag == "Player")
		{
            PlayerSound sound = collider.transform.parent.gameObject.GetComponent("PlayerSound") as PlayerSound; // tell my playersound to play the bad sound
            sound.PlayBadSound();
            GameManager.DecrementScore();
			Destroy(gameObject);
		}
	}

	//public void OnTrigg
}