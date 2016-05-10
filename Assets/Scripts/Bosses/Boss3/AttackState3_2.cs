using UnityEngine;
using System.Collections;

public class AttackState3_2 : IEnemyState3 {
	private readonly StatePatternEnemy3 enemy;
	private GameObject player;

	public AttackState3_2(StatePatternEnemy3 statePatternEnemy)
	{
		enemy= statePatternEnemy;
		player=GameObject.FindGameObjectWithTag("Player");

	}
	public void UpdateState (){

	}

	public void OnTriggerEnter2D(Collider2D other){

	}

	public void ToPatrolState(){

	}

	public void ToAttackState(){


	}

	public void ToAttackState2(){


	}


	void Look()
	{	
		enemy.playerInRange=Physics2D.OverlapCircle(enemy.transform.position,enemy.playerRange,enemy.playerLayer);
		if(enemy.playerInRange)
		{

			enemy.bossActivate = true;
		}

}
}
