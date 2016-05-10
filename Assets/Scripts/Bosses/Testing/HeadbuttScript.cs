using UnityEngine;
using System.Collections;

public class HeadbuttScript : MonoBehaviour {
public float moveSpeed=7;
public GameObject pillar;
public GameObject startHeadbutt;
private GameObject player;
private Animator anim;
public float someScale;
public bool readyHeadbutt=true;
private EnemyAI enemyAI;


//
public float minTime = 5f; 
 public float maxTime = 10f;
 public float minX = -5.5f;
 public float maxX = 5.5f;
 public float topY = 5.5f;
 public float z = 0.0f;
 public int count = 200;
 public GameObject prefab;
 
 public bool doSpawn ;

	// Use this for initialization
	void Start () {
		//StartHeadbutt();
		player=GameObject.FindGameObjectWithTag("Player");
		anim= GetComponent<Animator>();
		enemyAI= GetComponent<EnemyAI>();

	}

	// Update is called once per frame
	void Update () {
	if(readyHeadbutt == true){
		if(startHeadbutt.transform.position.x < transform.position.x ){
				transform.localScale= new Vector2(-someScale,transform.localScale.y);

			} else {
				transform.localScale= new Vector2(someScale,transform.localScale.y);
				}
			
		transform.position = Vector3.MoveTowards(transform.position, startHeadbutt.transform.position,moveSpeed *Time.deltaTime);

		}else{

			

		StartCoroutine (DoHeadbutt());
		}
	

	}	

	void StartHeadbutt(){
		
			if(startHeadbutt.transform.position.x < transform.position.x ){
				transform.localScale= new Vector2(-someScale,transform.localScale.y);

			} else {
				transform.localScale= new Vector2(someScale,transform.localScale.y);
				}
			
		transform.position = Vector3.MoveTowards(transform.position, startHeadbutt.transform.position,moveSpeed *Time.deltaTime);


	}

	IEnumerator DoHeadbutt(){
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		yield return new WaitForSeconds(2f);
		transform.position = Vector3.MoveTowards(transform.position, pillar.transform.position,moveSpeed *Time.deltaTime);

	}

	void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag == "Check"&& enemyAI.eCurState == EnemyAI.BossActionType.Headbutt){
		readyHeadbutt = false;
			if(pillar.transform.position.x < transform.position.x ){
				transform.localScale= new Vector2(-someScale,transform.localScale.y);

			} else {
				transform.localScale= new Vector2(someScale,transform.localScale.y);

			}
		}
		if(obj.tag == "Pillar" && enemyAI.eCurState == EnemyAI.BossActionType.Headbutt){
		anim.SetTrigger("Attack");
		enemyAI.patrolTime=0;
		doSpawn = true;
		//StartCoroutine(ChangeState());
			StartCoroutine(IcicleRain());
		//this.enabled=false;
		//return;
	
		}

	}

	IEnumerator ChangeState(){
		yield return new WaitForSeconds(3f);
		enemyAI.eCurState = EnemyAI.BossActionType.PatrolWaypoint;
	}

	IEnumerator IcicleRain(){
		while (doSpawn == true&& count > 0) {
         Vector3 v = new Vector3(Random.Range (minX, maxX), topY, z);
         Instantiate(prefab, v, transform.rotation);
         count--;
         yield return new WaitForSeconds(Random.Range(minTime, maxTime));
         if (count == minTime){
				doSpawn = false;
				StartCoroutine(ChangeState());
         }
     }

	}
}
