using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState {
	private readonly StatePatternEnemy enemy;


	public ChaseState(StatePatternEnemy statePatternEnemy)
	{
		enemy= statePatternEnemy;
	}
	// Use this for initialization
	public void UpdateState ()
	{
		Look();

	}

	public void OnTriggerEnter2D(Collider2D other)
	{

		if(other.tag == "Player"){

		ToAttackState();
		}
	}

	public void ToPatrolState()
	{
		enemy.currentState = enemy.patrolState;

	}

	public void ToChaseState()
	{

		Debug.Log("Can't transition to same state");
	}

	public void ToAttackState()
	{
		enemy.currentState = enemy.attackState;

	}
	private void Look()
	{	
		enemy.playerInRange=Physics2D.OverlapCircle(enemy.transform.position,enemy.playerRange,enemy.playerLayer);
		if(enemy.playerInRange)
		{
			enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.player.transform.position,enemy.moveSpeed *Time.deltaTime);
			return;


		} else {
		ToPatrolState();
		}


	}



	void OnDrawGizmosSelected(){
		Gizmos.DrawSphere(enemy.transform.position,enemy.playerRange);
	}
}
