using UnityEngine;
using System.Collections;

public class WaypointBoss3 : MonoBehaviour {
	public int _targetWaypoint=0;
	public int total_waypoints;
	public Transform[] waypoints;
	public bool facingRight = true;
	public bool flip = false;
	public bool stopOnLastWaypoint = false;
	public bool destroyOnLastWaypoint=false;
	private float someScale;
	public float reachDistance = 0.1f;
	private float distanceToWaypoint;
	public float movementSpeed = 3f;
	public bool randomizeWaypoint;
	private WaypointEnemy waypointScript;
	private EnemyAI enemyAI;
	
	int x=0;
	
	// Use this for initialization
	void Start () {
	waypointScript=GetComponent<WaypointEnemy>();
	total_waypoints=waypoints.Length;
	someScale = transform.localScale.x;
		if(flip){
		Flip();
		}
		if(randomizeWaypoint == true){
		RandomizeArray(waypoints);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(randomizeWaypoint == true && waypoints[_targetWaypoint] == waypoints[total_waypoints-1]){
		RandomizeArray(waypoints);
		}
	if(GetComponent<Rigidbody2D>().velocity.x >= 0  ){
			transform.localScale= new Vector2(someScale,transform.localScale.y);
			//someScale *= 1;
			
		}
		
		else{
		
			transform.localScale= new Vector2(-someScale,transform.localScale.y);
			//someScale *= -1;
		
		}

	}
	
	void FixedUpdate(){
		
	handleWaypoints();
	
	}

	void RandomizeArray(Transform[] enemyWP){
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

	void handleWaypoints(){
		Vector3 relative = waypoints[_targetWaypoint].position - transform.position;
		Vector3 movementNormal = Vector3.Normalize (relative);
		float distanceToWaypoint = relative.magnitude;
		
		if (distanceToWaypoint < 0.53f)
		{
			if(_targetWaypoint + 1 < waypoints.Length)
			{
				_targetWaypoint++;
			
			}
			
			else{
			if(stopOnLastWaypoint==true){
			
			this.GetComponent<Renderer>().enabled=false;
			}
			
			if(destroyOnLastWaypoint==true){
			Destroy(this);
			return;
			}
			else{
			_targetWaypoint = 0;
			}
		}
		}
		else{ 
		//rigidbody2D.AddForce(new Vector2(movementNormal.x,movementNormal.y) * movementSpeed);
			Vector2 moveVelocity = movementSpeed * new Vector2(movementNormal.x,movementNormal.y);
			GetComponent<Rigidbody2D>().velocity=new Vector2(moveVelocity.x,moveVelocity.y);
		}
	
	
	}
	
	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale=theScale;
		
	}
	
	void FlipPath(){
	for(int i=0 ; i< waypoints.Length ; i++){
	waypoints[i] = waypoints[total_waypoints];
	total_waypoints-=1;
	
	}
	
	/*for(int i = waypoints.Length ; i >= 0 ; i--){
		if(x<= waypoints.Length){
			waypoints[i] = waypoints[x];
			x++
			}
	
		}*/
	
	}
	
	void OnDrawGizmos(){
		if(waypoints == null)
		return;
		foreach(Transform waypoint in waypoints){
			Gizmos.DrawSphere(waypoint.position,reachDistance);
		
		}
	
	}
}
