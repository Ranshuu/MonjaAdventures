using UnityEngine;
using System.Collections;

public class Crawling : MonoBehaviour {
	public float moveSpeed;
	public bool moveRight=true;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool hittingGround;
	public int hitWallTimes=0;
	//public bool upsideDown;
	public bool stopCrawl = false;
	private SpiderlingSpawn spawnSpider;
	public bool endSpawn = false;

	private StatePatternEnemy2 statePattern;
	// Use this for initialization
	void Start () {
		
	statePattern= FindObjectOfType<StatePatternEnemy2>();
	spawnSpider = FindObjectOfType<SpiderlingSpawn>();
	GetComponent<Rigidbody2D>().gravityScale = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if(endSpawn == true){
		StartCoroutine(ToPatrol());
		Vector3 stop = new Vector3(0,0,0);
		transform.Translate( stop);
		transform.localRotation= Quaternion.Euler(0,0,0);
		GetComponent<Rigidbody2D>().gravityScale = 1;
		 if(hittingGround==true){
			transform.Translate(stop);
			spawnSpider.spawning = false;
			endSpawn = false;
			//statePattern.enabled=true;
			//statePattern.triggerAtk3=true;
			//statePattern.atk3=false;

		 }

		
	}

	if(stopCrawl == false && endSpawn == false){
			Vector3 stop = new Vector3(0,0,0);
		transform.Translate( stop);
		var absVelX= Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		
		hittingWall= Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius,whatIsWall);
		hittingGround= Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);

		if(hittingWall)
		{
		hitWallTimes ++;
		}
		if(hitWallTimes >3){
		hitWallTimes = 0;
		moveRight = true;
			
		}
		if (moveRight){
			transform.localScale = new Vector3(1f,1f,1f);
			transform.Translate(Vector3.right * (Time.deltaTime*moveSpeed));

		
		if(hittingWall && hitWallTimes >=1 ){
			
			transform.localRotation= Quaternion.Euler(0,0,90);
			transform.Translate(Vector3.right * (Time.deltaTime*moveSpeed));
	
			}
				if(hittingWall&& hitWallTimes > 1 ){

				transform.localRotation= Quaternion.Euler(0,0,180);
				transform.Translate(Vector3.right * (Time.deltaTime*-moveSpeed));

			}


				}
			}
		}

		void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag=="StopCrawl"){
		Debug.Log("StopCrawl");
		stopCrawl = true;
		spawnSpider.enabled=true;
		spawnSpider.spawning = true;


		}


		}

		IEnumerator ToPatrol(){
		yield return new WaitForSeconds(2f);
		statePattern.enabled=true;
		statePattern.triggerAtk3=true;
		statePattern.atk3=false;
		statePattern.startFlip=false;
		//statePattern.bossActivate=false;

		}


	}

