using UnityEngine;
using System.Collections;

public class AttackState2_2 : IEnemyState2 {

	private readonly StatePatternEnemy2 enemy;
	private GameObject player;

	//public float atk1Time=0;
	//public float atk2Time=0;

	public AttackState2_2(StatePatternEnemy2 statePatternEnemy)
	{
		enemy= statePatternEnemy;
		player=GameObject.FindGameObjectWithTag("Player");

		//specialAtt1 = enemy.instantiatedObj;
	}


	// Use this for initialization
	public void UpdateState ()
	{	
		//enemy.transform.position = enemy.waypoints[enemy._targetWaypoint].position;
		enemy._storeWaypoint.position=enemy.waypoints[enemy.total_waypoints - 1].position ;
		Look();


		if(enemy.playerInRange == true){
			enemy.DelaySkill();

			ToPatrolState();
			
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
		enemy._targetWaypoint = 0;
		enemy.startFlip=false;
		enemy.currentState = enemy.patrolState;

	}


	public void ToAttackState()
	{

		
	}

	public void ToAttackState2()
	{

		Debug.Log("Cant transition to same state");
	}

	public void ToAttackState3()
	{

		
	}

	public void ToIdleState()
	{

		
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
