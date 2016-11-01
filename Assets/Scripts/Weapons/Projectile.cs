using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour, IWeapon, IDoesDamage {
    private enum projectileStatus
    {
        active,
        decaying,
        destroy
    }

    private Vector3 target; //What I'm targeting
    private Rigidbody rb;
    public float thrust;
    public float lifeTime = 1; //How long I last
    private float startTime;
    private projectileStatus status = projectileStatus.active;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        if ((status == projectileStatus.active) && (Time.time - startTime >= lifeTime))
        {
            EndOfLife(); //If I'v hit my lifetime, run my EOL function
        }
    }

    public void SetTarget(Vector3 newTarget) {
        target = newTarget;
    }

    private void EndOfLife()
    {
        status = projectileStatus.decaying; // mark my status as decaying, so I don't repeat this the next frame
        rb.useGravity = true; //In this case, all EOL does is turn on gravity. When I hit the ground, the onTriggerEnter function will kill me.
    }

    public void fire()
    {
        Vector3 direction = (target - gameObject.transform.position).normalized;
        rb.AddForce(direction * thrust);
        startTime = Time.time;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ground")
        {
            status = projectileStatus.destroy;
            Destroy(gameObject);
        }
        else if (collider.tag == "Player")
        {
            Debug.Log("HIT PLAYER");
            Destroy(gameObject);
        }
    }
}
