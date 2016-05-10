using UnityEngine;
using System.Collections;

public class StatePatternEnemy2 : MonoBehaviour {
	public bool onAttack;
	public GameObject player;
	//check player nearby
	public float moveSpeed;
	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;

	public float groundRange;
	public LayerMask groundLayer;
	public bool groundInRange;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	[HideInInspector] public bool hittingWall;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	[HideInInspector] public bool hittingGround;
	public int hitWallTimes=0;
	//pathway
	[HideInInspector] public int _targetWaypoint=0;
	[HideInInspector] public int total_waypoints;
	public Transform[] waypoints;
	public Transform _storeWaypoint;
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
	public GameObject specialAtt3;
	public bool atk1;
	public bool atk2;
	public bool atk3;
	public float atk1Time=0;
	public int timesAtt=0;
	public bool startFlip=false;
	public bool startRandomize=false;
	int randomizeAtt=0;

	private GameObject instantiatedObj;
	public int check;

	public bool bossActivate;
	[HideInInspector] public IEnemyState2 currentState;
	[HideInInspector] public AttackState2 attackState;
	[HideInInspector] public AttackState2_2 attackState2;
	[HideInInspector] public AttackState2_3 attackState3;
	[HideInInspector] public PatrolState2 patrolState;
	[HideInInspector] public IdleState idleState;


	//crawlerscript
	private Crawling crawling;
	public bool stopCrawl = false;
	private SpiderlingSpawn spawnSpider;
	public bool endSpawn = false;
	public bool moveRight=true;
	//

	public CurveTest1 curveJump;
	private Vector3 targetPos;
	public float upForce=10f;
	public float jumpSpeed=5;
	public bool targetLock;
	public float t=0;
	public bool triggerAtk3;
	// Use this for initialization
	private void Awake()
	{	
		attackState= new AttackState2(this);
		attackState2= new AttackState2_2(this);
		attackState3= new AttackState2_3(this);
		patrolState= new PatrolState2(this);
		idleState = new IdleState(this);

	}
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		currentState = patrolState;
		///
		waypointScript=GetComponent<StatePatternEnemy>();
		total_waypoints=waypoints.Length;
		someScale = transform.localScale.x;

		//
		crawling = FindObjectOfType<Crawling>();
		spawnSpider = FindObjectOfType<SpiderlingSpawn>();
		//GetComponent<Rigidbody2D>().gravityScale = 0;
	}

	// Update is called once per frame
	void Update () 
	{	
		
		if(atk2 == false && atk1 == false && atk3 == false){
			//onAttack=false;
			startFlip=false;
			//crawling.enabled=false;
			spawnSpider.enabled=false;
			if(transform.position.x < waypoints[_targetWaypoint].transform.position.x){
			transform.localScale= new Vector2(-someScale,transform.localScale.y);
			Debug.Log("Should flip");

			}
			currentState= patrolState;

		}
		if(t>=1 && atk2 == true )
		{ 	
			
				atk2= false;
			 }

			if(onAttack == false){
			atk1=false;
			atk2=false;
			atk3=false;
			currentState= patrolState;
			}

	
		if(player == null || playerInRange == false){
		onAttack=false;
		bossActivate = false;
		transform.position = waypoints[_targetWaypoint].position; 
		currentState = patrolState;
		}



		if(GetComponent<Rigidbody2D>().velocity.x >= 0){
			transform.localScale= new Vector2(someScale,transform.localScale.y);
	
		}
		
		else{
		
			transform.localScale= new Vector2(-someScale,transform.localScale.y);
			Debug.Log("Should flip");
		}
		if(playerInRange == true && startFlip == true ){

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


	IEnumerator ExecuteSkill(){
		
		if(timesAtt <= 5 && GameObject.FindGameObjectWithTag("SpecialAtt")==null  )
			{	
			if(atk1 == true){
				if(player.transform.position.x < transform.position.x){
				transform.localScale= new Vector2(-someScale,transform.localScale.y);

			} else {
				transform.localScale= new Vector2(someScale,transform.localScale.y);

					}
				if(timesAtt <= 5 && GameObject.FindGameObjectWithTag("SpecialAtt")==null  )
			{		
					Instantiate(specialAtt1,transform.position, transform.rotation);
					instantiatedObj= GameObject.FindGameObjectWithTag("SpecialAtt");
					instantiatedObj.transform.position = transform.position;
					Vector2 direction = player.transform.position - instantiatedObj.transform.position;
					instantiatedObj.GetComponent<EnemySkillScript>().SetDirection(direction);
			timesAtt=timesAtt+1;
				yield return new WaitForSeconds(2f);
				Destroy(instantiatedObj);
				}else{
				currentState = patrolState;

				}

			}else{
				
				currentState = patrolState;
			}

		
			if(atk2 == true){

				/*if(transform.position.y >= 0){
					Vector3 tempY = new Vector3(transform.position.x,-1.45f,0);
				transform.position= tempY;

				}*/
				if ( targetLock == true){
				targetPos = new Vector3 (player.transform.position.x,-1.45f,0);
				//targetPos = player.transform.position;
				targetLock = false;
				}
				//yield return new WaitForSeconds(0.5f);
			
				StartCoroutine (TravelInCurve(targetPos, this.transform));
			
							
			}

			if(atk3 == true){
				

			
			}

		}
		}


	public IEnumerator TravelInCurve(Vector3 targetPos, Transform tr) {

	 float t = 0f;
	 float distance = Vector3.Distance(tr.position, targetPos);
	 float speed = 4f;
	 Debug.Log(t);
		//	yield return new WaitForSeconds(4f);
	 while(t < 1) {
		
      tr.position = Vector3.Lerp(tr.position, GetQuadraticCoordinates(t, tr.position + Vector3.up * 1.4f, Vector3.Lerp(tr.position, targetPos, 0.5f) + Vector3.up * (Vector3.Distance(tr.position, targetPos) / 2.0f), targetPos), t);
      t += Time.deltaTime / distance * speed;
      if(targetPos.x < tr.position.x){
				transform.localScale= new Vector2(-someScale,transform.localScale.y);

      }
      if(t>0.1){
	groundInRange=Physics2D.OverlapCircle(transform.position,groundRange,groundLayer);
	if(groundInRange == true){
				
			onAttack = false;
					if(transform.position.x < waypoints[_targetWaypoint].transform.position.x){
					transform.localScale= new Vector2(-someScale,transform.localScale.y);
					Debug.Log("Should flip");
						yield return null;

					}
			transform.position = Vector3.MoveTowards(transform.position, waypoints[_targetWaypoint].transform.position,moveSpeed * Time.deltaTime);

			currentState = patrolState;
			t = 1;
			}
      }
      yield return null;
		 }if ( t >= 1){
		 if(transform.position == waypoints[total_waypoints-1].transform.position){

		 waypoints[total_waypoints-1] = waypoints[0];
		transform.position = Vector3.MoveTowards(transform.position, waypoints[_targetWaypoint].transform.position,moveSpeed * Time.deltaTime);

		
		 }
					atk2=false;
					t=0;

			//transform.position = Vector3.MoveTowards(transform.position, waypoints[_targetWaypoint].transform.position,moveSpeed * Time.deltaTime);

 				currentState = patrolState;
			
 		}
 }
     
     public Vector3  GetQuadraticCoordinates(float t, Vector3 p0, Vector3 c0, Vector3 p1) 
     {
         return Mathf.Pow(1 - t, 2) *  p0 + 2 * t * (1 - t) * c0 + Mathf.Pow(t, 2) * p1;
     }

	public void DelaySkill(){

				//InvokeRepeating("ExecuteSkill",2,2);
				StartCoroutine(ExecuteSkill());


	}



	public void ChangeSkill(){
	Debug.Log("randomize");
	atk1=false;
	atk2=false;
	atk3=false;

	if(startRandomize == true){
		randomizeAtt= Random.Range(1,4);
		startRandomize = false;

		//transform.position = waypoints[_targetWaypoint].position;
		transform.position=_storeWaypoint.position;
		//_storeWaypoint.position = transform.position;
			switch (randomizeAtt)
			{
			case 1:
				print("Spider Web Attack");
				atk3 = true;
				onAttack=true;
				check=0;
				//targetLock = true;
				//startFlip = true;
				//searchTimer= 0 ;
				currentState = attackState3;
				break;
			case 2:
				print("Stomp Attack");
				atk3 = true;
				onAttack=true;
				check=0;
				//targetLock = true;
				currentState = attackState3;
				break;
			case 3:
				print("Hypersonic Wave Attack");

				atk3=true;
				onAttack=true;
				//targetLock = true;
				check=0;
				currentState = attackState3;
				break;
			default:
				print("Idle....");
				break;
			}

		}
	}


}
