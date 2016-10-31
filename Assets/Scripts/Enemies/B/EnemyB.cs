using UnityEngine;
using System.Collections;

public class EnemyB : Enemy {


    //Start attack when I'm in range
    public override void InRange(Vector3 target)
    {
        // tell my attack module to attack
        //aAttack.StartAttack();
    }

    //Stop attack when I'm out of range
    public override void OutRange()
    {
        //aAttack.StopAttack();
    }
}
