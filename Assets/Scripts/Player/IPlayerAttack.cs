using UnityEngine;
using System.Collections;

/*
 * Interface that defines behaviors for a player attack.
 * 
 */
public interface IPlayerAttack {

    void Attack(Vector3 InDirection); //attack in a given direction
    void EndAttack();
}
