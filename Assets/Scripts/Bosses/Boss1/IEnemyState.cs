using UnityEngine;
using System.Collections;

public interface IEnemyState{
//Interface allows us to establish a sort of code contract between our different scripts
//so int his case we can use our different state classes interchangebly because theyre gonna implement this IEnemyState

	
	// Update is called once per frame
	void UpdateState ();

	void OnTriggerEnter2D(Collider2D other);

	void ToPatrolState();

	void ToChaseState();

	void ToAttackState();

}
