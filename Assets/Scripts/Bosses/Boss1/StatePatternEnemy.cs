using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour {
	public bool onAttack;
	public GameObject player;
	//check player nearby
	public float moveSpeed;
	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;
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
	public float atk1Time=0;
	public bool atk2;

	private GameObject instantiatedObj;
	public int check;

	public bool bossActivate;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public PatrolState patrolState;

	private void Awake()
	{	
		chaseState = new ChaseState (this);
		attackState= new AttackState(this);
		patrolState= new PatrolState(this);

	}
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		currentState = patrolState;
		///
		waypointScript=GetComponent<StatePatternEnemy>();
		total_waypoints=waypoints.Length;
		someScale = transform.localScale.x;

	}

	// Update is called once per frame
	void Update () 
	{	if(player == null || playerInRange == false){
		onAttack=false;
		bossActivate = false;
		transform.position = waypoints[_targetWaypoint].position; 
		currentState = patrolState;
		}


		if(GameObject.FindGameObjectWithTag("SpecialAtt") != null ||GameObject.FindGameObjectWithTag("SpecialAtt2") != null){

		atk1Time+= Time.deltaTime;
			if (atk1Time > 2f || instantiatedObj.transform.position== player.transform.position){
			Destroy(instantiatedObj);
			//Destroy(specialAtt1);
			atk1Time = 0;
			}
		}


		if(GetComponent<Rigidbody2D>().velocity.x >= 0){
			transform.localScale= new Vector2(someScale,transform.localScale.y);
			//someScale *= 1;

		}
		
		else{
		
			transform.localScale= new Vector2(-someScale,transform.localScale.y);
			//someScale *= -1;
			Debug.Log("Should flip");
		}
		if(playerInRange == true){

			if(player.transform.position.x < transform.position.x){
				transform.localScale= new Vector2(-someScale,transform.localScale.y);

			} else {
				transform.localScale= new Vector2(someScale,transform.localScale.y);

			}

		}
		currentState.UpdateState();

		
		}
	

	private void OnTriggerEnter2D (Collider2D other) 
	{

		currentState.OnTriggerEnter2D(other);
	}

	void Waiting(){
	if (atk1Time > 2f || instantiatedObj.transform.position== player.transform.position){
			Destroy(instantiatedObj);
			//Destroy(specialAtt1);
			atk1Time = 0;
	}


	}

	void SpecialOne(){
		//Waiting();

		if (GameObject.FindGameObjectWithTag("SpecialAtt")==null && player != null && atk1Time==0 ){
				Debug.Log("attack player");
			check=check+1;
			Instantiate(specialAtt1,transform.position, transform.rotation);
			instantiatedObj= GameObject.FindGameObjectWithTag("SpecialAtt");
			instantiatedObj.transform.position = transform.position;
			Vector2 direction = player.transform.position - instantiatedObj.transform.position;
			instantiatedObj.GetComponent<EnemySkillScript>().SetDirection(direction);


			}

		
	}
	void SpecialTwo(){
		//Waiting();

		if (GameObject.FindGameObjectWithTag("SpecialAtt2")==null && player != null && atk1Time==0 ){
				Debug.Log("attack player");
			check=check+1;
			Instantiate(specialAtt2,transform.position, transform.rotation);
			instantiatedObj= GameObject.FindGameObjectWithTag("SpecialAtt2");
			instantiatedObj.transform.position = transform.position;
			Vector2 direction = player.transform.position - instantiatedObj.transform.position;
			instantiatedObj.GetComponent<EnemySkillScript>().SetDirection(direction);


			}

		
	}

	IEnumerator DeploySkill(){
	if( check <=5){
		if(atk1 == true  && atk2 == false)
		{SpecialOne();}
		else {
		SpecialTwo();
		}
		yield return new WaitForSeconds(2f);
		}else{
		currentState=patrolState;
		}

	}

	public void startAttack(){

	StartCoroutine(DeploySkill());


	}

	public void ChangeSkill(){
	if(onAttack == true){
		int targetSkill = Random.Range(1,5);
					if(targetSkill == 1)
					{ atk1 = true;
						atk2 = false;

					}
					else {

					 atk2 = true;
					atk1 = false;
				
					}
			}else{

			atk2 = false;
			atk1 = false;
			}

	}


}

