using UnityEngine;
using System.Collections;

public class AttackState : IEnemyState {
	private readonly StatePatternEnemy enemy;
	private GameObject spec1;
	private GameObject spec2;
	private GameObject player;

	//public float atk1Time=0;
	//public float atk2Time=0;

	public AttackState(StatePatternEnemy statePatternEnemy)
	{
		enemy= statePatternEnemy;
		player=GameObject.FindGameObjectWithTag("Player");

		//specialAtt1 = enemy.instantiatedObj;
	}


	// Use this for initialization
	public void UpdateState ()
	{	
		/*if(GameObject.FindGameObjectWithTag("SpecialAtt") != null ){

		enemy.atk1Time+= Time.deltaTime;
			if (enemy.atk1Time > 2f || enemy.instantiatedObj.transform.position== player.transform.position){

			enemy.atk1Time = 0;
			}
		}*/

		Look();


		if(enemy.playerInRange == true){
			
			//enemy.transform.position = enemy.waypoints[enemy.waypoints.Length-1].position;
			enemy.transform.position = enemy.waypoints[enemy._targetWaypoint+1].position;
			enemy.startAttack();

			
			}
		}

	public void OnTriggerEnter2D(Collider2D other)
	{
		


	}

	public void ToPatrolState()
	{	
		
		enemy.atk1 = false;
		enemy.atk2 = false;
		enemy.onAttack = false;
		enemy.currentState = enemy.patrolState;

	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;

	}

	public void ToAttackState()
	{

		Debug.Log("Cant transition to same state");
	}

/*	void SpecialOne(){
		Debug.Log("Attacking");
		if (GameObject.FindGameObjectWithTag("SpecialAtt")==null && enemy.player!=null && enemy.atk1Time==0 ){
				Debug.Log("attack player");
			
			GameObject specialAtt1 = enemy.instantiatedObj;
			GameObject spec1 = GameObject.Instantiate(specialAtt1,enemy.transform.position, enemy.transform.rotation) as GameObject;
			spec1.transform.position = enemy.transform.position;
			Vector2 direction = player.transform.position - spec1.transform.position;
			spec1.GetComponent<EnemySkillScript>().SetDirection(direction);


			}

		

		
	}

	void SpecialTwo(){
		Debug.Log("Attacking");
		if (GameObject.FindGameObjectWithTag("SpecialAtt")==null && enemy.player!=null && enemy.atk1Time==0 ){
				Debug.Log("attack player");
			
			GameObject specialAtt2 = enemy.instantiatedObj2;
			GameObject spec2 = GameObject.Instantiate(specialAtt2,enemy.transform.position, enemy.transform.rotation) as GameObject;
			spec2.transform.position = enemy.transform.position;
			Vector2 direction = player.transform.position - spec2.transform.position;
			spec2.GetComponent<EnemySkillScript>().SetDirection(direction);


			}

		

		
	}*/




	void Look()
	{	
		enemy.playerInRange=Physics2D.OverlapCircle(enemy.transform.position,enemy.playerRange,enemy.playerLayer);
		if(enemy.playerInRange)
		{
			//enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.player.transform.position,enemy.moveSpeed *Time.deltaTime);
			//handleWaypoints();

			enemy.bossActivate = true;
		}

	


	}
}

