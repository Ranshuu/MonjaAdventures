using UnityEngine;
using System.Collections;

public interface IEnemyState3 {

	void UpdateState ();

	void OnTriggerEnter2D(Collider2D other);

	void ToPatrolState();

	void ToAttackState();

	void ToAttackState2();

}
