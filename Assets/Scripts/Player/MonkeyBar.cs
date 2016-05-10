using UnityEngine;
using System.Collections;

public class MonkeyBar : MonoBehaviour {
private PlayerNormalCont player;
private Animator anim;
public bool onHandle=false;
private Vector2 transPos;
public float force= 5;
	// Use this for initialization
	void Start () {
	player= FindObjectOfType<PlayerNormalCont>();
	anim=player.GetComponent<Animator>();
	transPos=player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	if(onHandle == true){
	transPos.y = this.transform.position.y ;
	player.GetComponent<Rigidbody2D>().gravityScale=0;
	player.GetComponent<Rigidbody2D>().mass=0;
	if(Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A)){
	anim.SetBool("ClimbUpMove",true);
	}
	if(Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A)){
		anim.SetBool("ClimbUpMove",false);
	}
			if (Input.GetKey (KeyCode.D)){
				player.transform.localScale = new Vector3(1f,1f,1f);
				player.transform.position+= new Vector3(force * Time.deltaTime, 0.0f,0.0f);
			//	player.rigidbody2D.AddForce(player.transform.right * force);
			} else if (Input.GetKey (KeyCode.A)){
				player.transform.localScale = new Vector3(-1f,1f,1f);
				player.transform.position-= new Vector3(force * Time.deltaTime, 0.0f,0.0f);
			//	player.rigidbody2D.AddForce(player.transform.right * -force);
			} 
			
	}
	}
	
	void OnTriggerEnter2D (Collider2D other){
	
	if (other.tag == "Player"){
	anim.SetBool("ClimbUp",true);
	onHandle=true;
			
	
	
	}
	}
	
	void OnTriggerExit2D(Collider2D other){
		player.GetComponent<Rigidbody2D>().gravityScale=2.5f;
		player.GetComponent<Rigidbody2D>().mass=0.5f;
		if (other.tag == "Player"){
			anim.SetBool("ClimbUp",false);
			onHandle=false;
		}
	
	}
}
