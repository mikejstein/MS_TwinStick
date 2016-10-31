using UnityEngine;
using System.Collections;

public class EnemyAMovement : EnemyMovement {

    new void Start()
    {
        base.Start();
    }

    public void ChangeSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }
}
