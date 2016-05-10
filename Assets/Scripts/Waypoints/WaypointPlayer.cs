using UnityEngine;
using System.Collections;

public class WaypointPlayer : MonoBehaviour {
public GameObject player;
//public PlayerNormalCont player;
private Rigidbody2D playerRigidbody;
//public bool disableCtrl = false;
//public GameObject playeronwaypoint;
private GameObject autoMove;
private CameraController camera;
private ActivateWaypoint actwaypoint;

private int _targetWaypoint=0;
private int total_waypoints;
public Transform[] waypoints;
public bool facingRight = true;
public bool flip=false;
public bool stopOnLastWaypoint=false;
public bool destroyOnLastWaypoint=false;
public bool deactivateOnLastWaypoint;
public float movementSpeed = 3f;
private float someScale;
public float reachDistance = 5.0f;
private float distanceToWaypoint;
private WaypointPlayer walker;



	// Use this for initialization
	void Start () {
	autoMove=GameObject.FindGameObjectWithTag("automove");
	camera= FindObjectOfType<CameraController>();
	//player=FindObjectOfType<PlayerNormalCont>();
	playerRigidbody=autoMove.GetComponent<Rigidbody2D>();
	//player=GameObject.FindGameObjectWithTag("Player");
	someScale = player.transform.localScale.x;
	actwaypoint=FindObjectOfType<ActivateWaypoint>();
	//player.transform.position=autoMove.transform.position;
	autoMove.transform.position=player.transform.position;
	total_waypoints=waypoints.Length;
	if(flip == true){
	Flip();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerRigidbody.velocity.x >= 0) 
		{
			autoMove.transform.localScale = new Vector2(someScale, autoMove.transform.localScale.y);  
			
		}
		
		else
		{
			autoMove.transform.localScale = new Vector2(-someScale, autoMove.transform.localScale.y);
		}
		
	
	}
	
	void FixedUpdate()
	{
//		handleWalkWaypoints();
		
	}
	
	/*private void handleWalkWaypoints()
	{
		if(actwaypoint.activateAutoMove == true){
		Vector3 relative = waypoints[_targetWaypoint].position - autoMove.transform.position;
		Vector3 movementNormal = Vector3.Normalize(relative);
		float distanceToWaypoint = relative.magnitude;
		
		if (distanceToWaypoint < 0.53f)
		{ Debug.Log ("Distance <0.1");
			if (_targetWaypoint + 1 < waypoints.Length)
			{
				// Set new waypoint as target
				_targetWaypoint++;
			}
			
			else
			{	if(stopOnLastWaypoint==true){
					
					walker= this.GetComponent<WaypointPlayer>();
					walker.enabled=false;
					
					player.SetActive(true);
					player.transform.position=autoMove.transform.position;
					//player.SetActive(false);
					autoMove.SetActive(false);
					autoMove.transform.position=waypoints[0].position;
					actwaypoint.activateAutoMove =false;
					if(deactivateOnLastWaypoint){
						//this.transform.collider2D.enabled=false;
						this.enabled=false;
					}
				}
				
				if(destroyOnLastWaypoint==true){
					Destroy(gameObject);
					return;
				}
				
				
				
				else{
					_targetWaypoint = 0;
				}
				
		////////////////		
				/*controller=player.GetComponent<PlayerController>();
				controller.enabled=true;
				player.rigidbody2D.gravityScale=3;
				player.rigidbody2D.drag=0;*/
				///////////////////
		/*	}
		}
		else
		{Debug.Log ("Distance >0.1");
			// Walk towards waypoint
			//player.rigidbody2D.AddForce(new Vector2(movementNormal.x, movementNormal.y) * movementSpeed);
			Vector2 moveVelocity = movementSpeed * new Vector2(movementNormal.x,movementNormal.y);
			playerRigidbody.velocity=new Vector2(moveVelocity.x,moveVelocity.y);
		}
		
		}
	}*/
	
	void Flip()
	{
		Vector3 theScale = autoMove.transform.localScale;
		theScale.x *= -1;
		autoMove.transform.localScale = theScale;
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
