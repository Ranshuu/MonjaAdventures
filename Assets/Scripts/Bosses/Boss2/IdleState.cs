using UnityEngine;
using System.Collections;

public class IdleState : IEnemyState2 {
	private readonly StatePatternEnemy2 enemy;
	private GameObject player;
	// Use this for initialization
	public IdleState(StatePatternEnemy2 statePatternEnemy)
	{
		enemy= statePatternEnemy;
		player=GameObject.FindGameObjectWithTag("Player");

	}


	// Use this for initialization
	public void UpdateState ()
	{	

		Look();


		if(enemy.playerInRange == true){
			
			//enemy.transform.position = enemy.waypoints[enemy.waypoints.Length-1].position;
			enemy.transform.position = enemy.waypoints[enemy._targetWaypoint+1].position;
			enemy.ChangeSkill();

			
			}
		}

	public void OnTriggerEnter2D(Collider2D other)
	{
		


	}

	public void ToPatrolState()
	{	
		
		enemy.atk1 = false;
		enemy.atk2 = false;
		enemy.atk3 = false;
		enemy.onAttack = false;
		enemy.currentState = enemy.patrolState;

	}


	public void ToAttackState()
	{

		
	}

	public void ToAttackState2()
	{

		
	}

	public void ToAttackState3()
	{

		
	}

	public void ToIdleState()
	{

		Debug.Log("Cant transition to same state");
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
