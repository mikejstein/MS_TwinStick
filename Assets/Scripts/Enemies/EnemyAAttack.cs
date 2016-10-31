using UnityEngine;
using System.Collections;

/*
 * Implementation of attack for enemy A.
 * Unqiue to the enemy is that the attack itself does damage, not a projectile.
 */
public class EnemyAAttack : MonoBehaviour, IDoesDamage {
    public float attackSpeed = 20f;

    /*
     * Reference to our movement component.
     * I'm not thrilled that these two components are talking together, but Enemy A attack is unique in that it
     * has no projectile and needs to change the movement element
     */
    private EnemyAMovement aMove;

    //Setter for movement. Won't see it in the inspector, and keeps people from accidentally changing it through the attack componenet.
    public void setMovement(EnemyAMovement _aMove)
    {
        aMove = _aMove;
    }


    /*
     * Stop the attack, which means we need to set our movement speed back to normal
     */
    public void StopAttack()
    {
        aMove.ChangeSpeed(aMove.moveSpeed);
    }

    /*
     * Start the attack - set move speed to our attack speed
     */ 
    public void StartAttack()
    {
        aMove.ChangeSpeed(attackSpeed);
    }

    /*
     * Register that we've hit the player
     */
    void IDoesDamage.OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            Debug.Log("HIT PLAYER");
        }
    }
}
