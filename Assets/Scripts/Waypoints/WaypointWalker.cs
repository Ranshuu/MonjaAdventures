
using UnityEngine;
using System.Collections;

public class WaypointWalker : MonoBehaviour 
{
	private int _targetWaypoint = 0;
	private int total_waypoints;
	public Transform[] waypoints;
	public bool facingRight = true;
	public bool flip = false;
	public bool stopOnLastWaypoint=false;
	public bool destroyOnLastWaypoint=false;
	public bool deactivateOnLastWaypoint;
	private float someScale;
	public float reachDistance = 5.0f;
	private float distanceToWaypoint;
	private WaypointWalker walker;
	private PlayerNormalCont controller;
	public GameObject player;
	public GameObject puppet;
	public CameraController camera1;
	public CameraController1 camera2;
	//public Transform targetWaypoint;
	
	public float movementSpeed = 3f;
	
	// Use this for initialization
	void Start () 
	{	
	Debug.Log ("Camera disabled");
		//_waypoints = GameObject.Find("Waypoints").transform;
		someScale = player.transform.localScale.x;
		player.transform.position=puppet.transform.position;
		total_waypoints=waypoints.Length;
		if(flip){
		Flip();
		}
		//waypoints=new Transform[5];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.GetComponent<Rigidbody2D>().velocity.x >= 0) 
		{
			player.transform.localScale = new Vector2(someScale, player.transform.localScale.y);  
	        
		}
		
		else
		{
			player.transform.localScale = new Vector2(-someScale, player.transform.localScale.y);
		}
		
	}
	
	// Fixed update
	void FixedUpdate()
	{
		handleWalkWaypoints();
		
	}
	
	// Handle walking the waypoints
	private void handleWalkWaypoints()
	{	camera1.enabled=false;
		camera2.enabled = true;
		//targetWaypoint = _waypoints[_targetWaypoint];
		Vector3 relative = waypoints[_targetWaypoint].position - player.transform.position;
		Vector3 movementNormal = Vector3.Normalize(relative);
		float distanceToWaypoint = relative.magnitude;
		
		/*if () 
         {
             facingRight = false;
         }
 
         if () 
         {
             facingRight = true;
         }
         
         if (!facingRight)
         {
             Flip();
         }
         else if (facingRight)
         {
             Flip();
         }*/
		
		
		if (distanceToWaypoint < 0.53f)
		{ Debug.Log ("Distance <0.1");
			if (_targetWaypoint + 1 < waypoints.Length)
			{
				// Set new waypoint as target
				_targetWaypoint++;
			}
			
			else
			{	if(stopOnLastWaypoint==true){
					
					walker= this.GetComponent<WaypointWalker>();
					walker.enabled=false;
					
					puppet.SetActive(true);
					puppet.transform.position=player.transform.position;
					player.SetActive(false);
					player.transform.position=waypoints[0].position;
					camera1.enabled=true;
					camera2.enabled = false;
					if(deactivateOnLastWaypoint){
						this.transform.GetComponent<Collider2D>().enabled=false;
					}
					}
					
					if(destroyOnLastWaypoint==true){
					Destroy(gameObject);
					return;
					}
					
					
						
				else{
				_targetWaypoint = 0;
				}
				
				
				/*controller=player.GetComponent<PlayerController>();
				controller.enabled=true;
				player.rigidbody2D.gravityScale=3;
				player.rigidbody2D.drag=0;*/
			}
		}
		else
		{Debug.Log ("Distance >0.1");
			// Walk towards waypoint
			player.GetComponent<Rigidbody2D>().AddForce(new Vector2(movementNormal.x, movementNormal.y) * movementSpeed);
		}
		
	}
	
	void Flip()
	{
		Vector3 theScale = player.transform.localScale;
		theScale.x *= -1;
		player.transform.localScale = theScale;
	}
	
	void FlipPath(){
	for (int i=0 ;i< waypoints.Length ;i++){
	
	waypoints[i]= waypoints[total_waypoints];
	total_waypoints-=1;
	
	}
	}
	
	void OnDrawGizmos(){
		if(waypoints == null)
			return;
		foreach(Transform waypoint in waypoints){
			if(waypoint){
				Gizmos.DrawSphere (waypoint.position,reachDistance);
			}
		}
	}
	
}