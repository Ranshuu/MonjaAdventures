using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {
	private PlayerNormalCont player;
	public Vector2 moving = new Vector2();
	private Animator anim;
	public bool onLadder;
	public int climbspeed = 5;
	public KeyCode Up;
	public KeyCode Down;
	public KeyCode SpaceBar;
	public KeyCode Left;
	public KeyCode Right;
	/*public Transform edgeAboveCheck;
	public float edgeCheckRadius;
	public LayerMask whatIsEdge;
	public bool onEdgeClimb;*/
	
	// Use this for initialization
	void Start () {
		player=FindObjectOfType<PlayerNormalCont>();
		anim=player.GetComponent<Animator>();
	//	onEdgeClimb=Physics2D.OverlapCircle(edgeAboveCheck.position,edgeCheckRadius,whatIsEdge);
	}
	
	void Update(){
	if(player.onHurt == false)
	if(onLadder){
	//Destroy (player.rigidbody2D);
	player.GetComponent<Rigidbody2D>().isKinematic=true;
	player.enabled=false;
			if (Input.GetKey(Up)){
				//moving.y=-1f;
				//transform.position+= new Vector3(0.0f,climbforce * Time.deltaTime,0.0f);
				//player.rigidbody2D.AddForce(player.transform.up * climbforce);
				player.transform.Translate(Vector3.up * (Time.deltaTime*climbspeed));
				anim.SetBool("Climbing",true);
				
			} 
			if (Input.GetKeyUp(Up)){
				
				anim.SetBool("Climbing",false);
				
			} 
			
			 if (Input.GetKey (Down)){
				//moving.y=-1f;
				//transform.position-= new Vector3(0.0f,climbforce * Time.deltaTime,0.0f);
				player.transform.Translate(Vector3.down * (Time.deltaTime*climbspeed));
				anim.SetBool("Climbing",true);
			}
			
			if (Input.GetKeyUp(Down)){
				
				anim.SetBool("Climbing",false);
				
			} 
			
			if ((Input.GetKey (Left) || Input.GetKey(Right)) && Input.GetKey(SpaceBar) ){
				player.enabled=true;
				anim.SetBool("Climb",false);
				anim.SetBool("Climbing",false);
				onLadder = false;
				player.controlenabled=true;
			}
	
		}
	}
	
	
	
	
	void OnTriggerEnter2D (Collider2D other)
	{	
		if(other.tag == "Player" && onLadder == false){
			player.GetComponent<Rigidbody2D>().isKinematic=false;
			anim.SetBool("Climb",true);
			onLadder = true;
			player.controlenabled=false;
			player.moveVelocity=0;
			player.Jump();
			//player.rigidbody2D.isKinematic=true;
		//	player.rigidbody2D.AddForce(player.transform.up * climbforce);
		//	moving.y=-1f;
		//	player.transform.position+= new Vector3(0.0f,climbforce * Time.deltaTime,0.0f);
		
		}
		
		
	}
	
	void OnTriggerExit2D (Collider2D other)
	{if(onLadder == true){
			player.enabled=true;
			anim.SetBool("Climb",false);
			anim.SetBool("Climbing",false);
			onLadder = false;
			player.controlenabled=true;
		
		}
		
	}
	
	IEnumerator DisableCollider(){
		GetComponent<Collider2D>().enabled=false;
		yield return new WaitForSeconds(0.5f);
		GetComponent<Collider2D>().enabled=true;
		
	}
}
