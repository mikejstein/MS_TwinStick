using UnityEngine;
using System.Collections;

public class EnemyBAttack : MonoBehaviour, IAttack {
    public GameObject projectile;
    public GameObject spawnPoint;
    public float coolDown;
    private float lastFireTime;
    // Use this for initialization
    void Start () {
        lastFireTime = Time.time - coolDown;
	}
	

    public void StopAttack()
    {
       
    }

    /*
     * Start the attack - set move speed to our attack speed
     */
    public void StartAttack(Vector3 target)
    {
        //Instantiate the projectile
        if (Time.time - lastFireTime >= coolDown)
        {
            GameObject rocket = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            rocket.GetComponent<Projectile>().SetTarget(target);
            rocket.GetComponent<Projectile>().fire();
            lastFireTime = Time.time;
        }

    }
}
