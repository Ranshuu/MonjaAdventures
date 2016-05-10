using UnityEngine;
using System.Collections;

public class PatrolState3 : IEnemyState3 {
	private readonly StatePatternEnemy3 enemy;
	private GameObject player;
	private bool hittingWall;
	private bool hittingEdge;
	private Animator animator;
	// Use this for initialization
	public PatrolState3(StatePatternEnemy3 statePatternEnemy)
	{	Debug.Log("State: Patrol");
		enemy= statePatternEnemy;
		player=GameObject.FindGameObjectWithTag("Player");
		animator = enemy.GetComponent<Animator>();
	}

	
	// Update is called once per frame
	public void UpdateState() {
		var absVelX= Mathf.Abs (enemy.GetComponent<Rigidbody2D>().velocity.x);
		
		hittingWall= Physics2D.OverlapCircle(enemy.wallCheck.position,enemy.wallCheckRadius,enemy.whatIsWall);
		hittingEdge= Physics2D.OverlapCircle(enemy.edgeCheck.position, enemy.edgeCheckRadius,enemy.whatIsEdge);
		
		if (hittingWall || !hittingEdge)
			enemy.moveRight =!enemy.moveRight;
		
		if (enemy.moveRight){
			Debug.Log("Walk Right");
			enemy.transform.localScale = new Vector3(1f,1f,1f);
			enemy.GetComponent<Rigidbody2D>().velocity = new Vector2 (enemy.moveSpeed, enemy.GetComponent<Rigidbody2D>().velocity.y);}
		else{
			Debug.Log("Walk Left");
			enemy.transform.localScale = new Vector3(-1f,1f,1f);
			enemy.GetComponent<Rigidbody2D>().velocity = new Vector2 (-enemy.moveSpeed, enemy.GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	public void OnTriggerEnter2D(Collider2D other){

	}


	public void ToPatrolState(){

	}

	public void ToAttackState(){


	}

	public void ToAttackState2(){


	}


}
