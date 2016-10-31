using UnityEngine;
using System.Collections;
using System;

public class EnemyA : Enemy {
    EnemyAMovement aMove;
    EnemyAAttack aAttack;
    new void Start()
    {
        base.Start(); //make sure to call the parent class's start function.
        aMove = movement as EnemyAMovement; //cast our movement component to an EnemyA versin
        aAttack = GetComponent<EnemyAAttack>();  //get our attack component
        aAttack.setMovement(aMove); //give our movement component to our attack component.
           
    }

    //Start attack when I'm in range
    public override void InRange(Vector3 target)
    {
        // tell my attack module to attack
        aAttack.StartAttack();
    }

    //Stop attack when I'm out of range
    public override void OutRange()
    {
        aAttack.StopAttack();
    }
}
