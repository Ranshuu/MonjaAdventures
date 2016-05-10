using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {
	public float force ;
	private PlayerNormalCont player;
	public bool ballLoaded=false;
	private Animator animator;
	
	
	// Use this for initialization
	void Start () {
		animator= GetComponent<Animator>();
		player=FindObjectOfType<PlayerNormalCont>();
	}
	
	void Update(){
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (ballLoaded){
			if(Input.GetKeyDown(KeyCode.Space)){
				
				player.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
				animator.SetTrigger("Launch");
				//ballLoaded=true;
				//AddForces();
			}
			
		}
		
		
	}
	
	
	void OnCollisionEnter2D (Collision2D other)
	{	
		if(other.gameObject.tag == "Player" ){
			ballLoaded=true;
			//player.rigidbody2D.AddForce(transform.up * force);
			//player.inputenabled=false;
			if (ballLoaded){
				if(Input.GetKeyDown(KeyCode.Space)){
					
					player.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
					animator.SetTrigger("Launch");
					//ballLoaded=true;
					//AddForces();
				}
				
			}
		}
	}
	
	void OnCollisionExit2D (Collision2D other)
	{	
		if(other.gameObject.tag == "Player" ){
			//	player.inputenabled=true;
			ballLoaded=false;
		}
	}
	
}

