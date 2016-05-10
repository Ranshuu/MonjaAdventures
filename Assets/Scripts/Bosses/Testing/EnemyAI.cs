using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private GameObject player;
	private Vector3 stop= new Vector3 (0,0,0);
	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;
	public bool bossActivate;
	[HideInInspector]public BossActionType eCurState;
	[HideInInspector]public PatrolBoss3 patrol;
	[HideInInspector]public WaypointBoss3 waypointPatrol;
	[HideInInspector]public HeadbuttScript headbutt;
	public float patrolTime;
	void Start(){
	player= GameObject.FindGameObjectWithTag("Player");
	patrol=GetComponent<PatrolBoss3>();
	waypointPatrol=GetComponent<WaypointBoss3>();
	eCurState = BossActionType.PatrolWaypoint;
	headbutt=GetComponent<HeadbuttScript>();
	}
	public enum BossActionType
{
    Idle,
    Headbutt,
    Patrolling,
    PatrolWaypoint,
    Attacking
}

void FixedUpdate(){
	Look();
	if(bossActivate == true && eCurState == BossActionType.Idle){
	eCurState=BossActionType.Patrolling;

	}
}
void Update(){
	switch (eCurState)
{
    case BossActionType.Idle:
        HandleIdleState();
        break;
 
    case BossActionType.Headbutt:
        HandleHeadbuttState();
        break;
 
    case BossActionType.Patrolling:
        HandlePatrollingState();
        break;

    case BossActionType.PatrolWaypoint:
    	HandlePatrolWaypointState();
    	break;
 
    case BossActionType.Attacking:
        HandleAttackingState();
        break;
	}
}

	void HandleIdleState(){


	}

	void HandleHeadbuttState(){
	headbutt.enabled=true;
	waypointPatrol.enabled = false;
	patrol.enabled=false;

	}

	void HandlePatrollingState(){
	patrol.enabled = true;
	waypointPatrol.enabled=false;
	headbutt.enabled=false;
	}

	void HandlePatrolWaypointState(){
	waypointPatrol.enabled = true;
	patrol.enabled=false;
	headbutt.enabled=false;
	patrolTime += Time.deltaTime;
		if(patrolTime > 10f){
		//transform.position = Vector3.MoveTowards(transform.position,waypointPatrol.waypoints[waypointPatrol._targetWaypoint].transform.position,waypointPatrol.movementSpeed *Time.deltaTime);
			eCurState=BossActionType.Headbutt;

		}else{
			headbutt.readyHeadbutt=true;
		}
		
	}

	void HandleAttackingState(){


	}

	void Look()
	{	
		playerInRange=Physics2D.OverlapCircle(transform.position,playerRange,playerLayer);
		if(playerInRange)
		{
		bossActivate = true;
		}

	}

}
