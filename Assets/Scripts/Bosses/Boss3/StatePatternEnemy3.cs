using UnityEngine;
using System.Collections;

public class StatePatternEnemy3 : MonoBehaviour {
	public GameObject player;
	private GameObject instantiatedObj;

	//check player nearby
	public float moveSpeed;
	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;

	// patrol

	public bool moveRight;
	
	public Transform wallCheck;
	public Transform edgeCheck;
	public float wallCheckRadius;
	public float edgeCheckRadius;
	public LayerMask whatIsWall;
	public LayerMask whatIsEdge;


	//pathway

	[HideInInspector] public int _targetWaypoint=0;
	[HideInInspector] public int total_waypoints;
	public Transform[] waypoints;
	public bool facingRight = true;
	public bool flip = false;
	public bool stopOnLastWaypoint = false;
	public bool destroyOnLastWaypoint=false;
 	public float someScale;
	public float reachDistance = 0.1f;
	[HideInInspector] public float distanceToWaypoint;
	public float movementSpeed = 3f;
	[HideInInspector] public StatePatternEnemy waypointScript;
	int x=0;
	public bool randomizeWaypoints;

	//attackstate

	public GameObject specialAtt1;
	public GameObject specialAtt2;
	public bool atk1;
	public bool atk2;
	public float atk1Time=0;

	public bool bossActivate;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState3 currentState;
	[HideInInspector] public AttackState3_1 attackState;
	[HideInInspector] public PatrolState3 patrolState;
	[HideInInspector] public AttackState3_2 attackState2;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		currentState = patrolState;
	}

	private void Awake()
	{	
		attackState= new AttackState3_1(this);
		attackState2= new AttackState3_2(this);
		patrolState= new PatrolState3(this);

	}

	// Update is called once per frame
	void Update () {
		if(player == null || playerInRange == false){
		bossActivate = false;
		//transform.position = waypoints[_targetWaypoint].position; 
		currentState = patrolState;
		}
		// flip sprite according to which way it walks
		if(GetComponent<Rigidbody2D>().velocity.x >= 0 && currentState != patrolState){
		transform.localScale= new Vector2(someScale,transform.localScale.y);
		}
		
		else{
			transform.localScale= new Vector2(-someScale,transform.localScale.y);
			Debug.Log("Should flip");
			}
	}
}
