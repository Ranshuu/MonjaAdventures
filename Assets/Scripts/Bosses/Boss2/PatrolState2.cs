using UnityEngine;
using System.Collections;

public class PatrolState2 : IEnemyState2 {

	private readonly StatePatternEnemy2 enemy;
	private float searchTimer;
	private SpiderlingSpawn spawnSpider;
	private Crawling crawling;
	public PatrolState2(StatePatternEnemy2 statePatternEnemy)
	{	spawnSpider= GameObject.FindObjectOfType<SpiderlingSpawn>();
		crawling=GameObject.FindObjectOfType<Crawling>();
		enemy= statePatternEnemy;
		if(enemy.randomizeWaypoints == true){
		RandomizeArray(enemy.waypoints);

		}
		if(enemy.flip){
		Flip();
		}
	}


	// Use this for initialization
	public void UpdateState ()
	{	Debug.Log("Current State: Patrol State");
		
		Look();
		enemy.timesAtt = 0;
		if(enemy.triggerAtk3 == true && enemy.transform.position == enemy.waypoints[enemy._targetWaypoint].transform.position){
		ToAttackState();

		}
		if(enemy.bossActivate == true ){
			
			if(enemy._targetWaypoint == enemy.waypoints.Length-1 && enemy.stopOnLastWaypoint == true){
				
			/*searchTimer += Time.deltaTime;
				if(searchTimer >=2f){
					enemy._targetWaypoint=0;
					searchTimer=0;

					//ToAttackState();
				}*/

				
			}

			handleWaypoints();



		
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="StopCrawl"){

		enemy.stopCrawl = true;
		spawnSpider.spawning = true;

		}

	}

	public void ToPatrolState()
	{

		Debug.Log("Cant transition to same state");
	}


	public void ToAttackState()
	{	
		//enemy.onAttack=true;
		//enemy.ChangeSkill();
		//enemy.check=0;
		//enemy.atk1 = true;
		//searchTimer= 0 ;
		/*if(enemy.randomizeWaypoints == true){
		RandomizeArray(enemy.waypoints);

		}*/

		enemy.ChangeSkill();


	}

	public void ToAttackState2()
	{	
		

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
		if(enemy.playerInRange )
		{

			enemy.bossActivate = true;
		}

	


	}



	 void OnDrawGizmos(){
		if(enemy.waypoints == null)
		return;
		foreach(Transform waypoint in enemy.waypoints){
			Gizmos.DrawSphere(waypoint.position,enemy.reachDistance);
		
		}
	
	}



	/*void FixedUpdate(){
	
	handleWaypoints();

	}*/

	void handleWaypoints(){
		
		Vector3 relative = enemy.waypoints[enemy._targetWaypoint].position - enemy.transform.position;
		Vector3 movementNormal = Vector3.Normalize (relative);
		float distanceToWaypoint = relative.magnitude;
	
		if (distanceToWaypoint < 0.53f)
		{ToAttackState();
			if(enemy._targetWaypoint + 1 < enemy.waypoints.Length)
			{	
				
				enemy._targetWaypoint++;


			}
			
			else{
				if(enemy.stopOnLastWaypoint==true ){
					enemy._storeWaypoint= enemy.waypoints[enemy._targetWaypoint];
					enemy.transform.position = enemy.waypoints[enemy._targetWaypoint].position;
					//enemy.startFlip = true;
					enemy.startRandomize = true;
					if(enemy.randomizeWaypoints == true){
					RandomizeArray(enemy.waypoints);

					}

					ToAttackState();


					//return;

			}else{
			

					enemy._targetWaypoint = 0;
					}

			
			}
		}
		else{ 
		//rigidbody2D.AddForce(new Vector2(movementNormal.x,movementNormal.y) * movementSpeed);
			Vector2 moveVelocity = enemy.movementSpeed * new Vector2(movementNormal.x,movementNormal.y);
			enemy.GetComponent<Rigidbody2D>().velocity=new Vector2(moveVelocity.x,moveVelocity.y);

		}
		searchTimer = 0;
			
	}

	public void RandomizeArray(Transform[] enemyWP){
		for (int i = enemyWP.Length-1; i>0 ; i--){
		//randomize waypoints
			int rnd = Random.Range (0,i);
		//save the value of the current i, otherwise it'll overright when we swap the values
			Transform temp = enemyWP[i];
		//swap the new and old values
			enemyWP[i]=enemyWP[rnd];
			enemyWP[rnd]=temp;

		}

		for (int i = 0;i< enemyWP.Length ; i++)
		{

				Debug.Log(enemyWP[i]);
		}

	}
	
	void Flip(){
		Vector3 theScale = enemy.transform.localScale;
		theScale.x *= -1;
		enemy.transform.localScale=theScale;
		
	}
	
	void FlipPath(){
		for(int i=0 ; i< enemy.waypoints.Length ; i++){
			enemy.waypoints[i] = enemy.waypoints[enemy.total_waypoints];
			enemy.total_waypoints-=1;
	
	}
}

	

}
