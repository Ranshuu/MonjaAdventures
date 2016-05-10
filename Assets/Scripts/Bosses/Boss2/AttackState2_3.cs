using UnityEngine;
using System.Collections;

public class AttackState2_3 : IEnemyState2 {
	private readonly StatePatternEnemy2 enemy;
	private GameObject player;
	public GameObject attackPoint;
	private Crawling crawling;
	private SpiderlingSpawn spawn;
	//public float atk1Time=0;
	//public float atk2Time=0;

	public AttackState2_3(StatePatternEnemy2 statePatternEnemy)
	{
		enemy= statePatternEnemy;
		player=GameObject.FindGameObjectWithTag("Player");
		crawling= GameObject.FindObjectOfType<Crawling>();
		spawn = GameObject.FindObjectOfType<SpiderlingSpawn>();
		//enemy.crawling = true;
		//specialAtt1 = enemy.instantiatedObj;
	}


	// Use this for initialization
	public void UpdateState ()
	{	if(enemy.playerInRange == true){

			
			//enemy.transform.position = enemy.waypoints[enemy._targetWaypoint+1].position;
			enemy.DelaySkill();

			}
		if(enemy.atk3 == true){
		Debug.Log("enable crawl");
		crawling.enabled=true;
		enemy.enabled=false;
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

		
	}

	public void ToAttackState3()
	{

		Debug.Log("Cant transition to same state");
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
