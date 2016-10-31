using UnityEngine;
using System.Collections;

public class EnemyBAttack : MonoBehaviour {
    public GameObject projectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StopAttack()
    {
       
    }

    /*
     * Start the attack - set move speed to our attack speed
     */
    public void StartAttack()
    {
        /*
        * 1. Instantiate the projectile.
        * 2. Fire the projectile.
        * 3. Start a co-routine for when we fire the next projectile
        */
    }
}
