using UnityEngine;
using System.Collections;

public interface IAttack
{
	void StartAttack(GameObject target); 
    void StopAttack();
}
