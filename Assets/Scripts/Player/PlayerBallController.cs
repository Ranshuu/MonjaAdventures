using UnityEngine;
using System.Collections;

public class PlayerBallController : MonoBehaviour {
private Animator anim;
private PlayerNormalCont player;
public Vector2 moving = new Vector2(); //set move animation
public float speed = 3f;
public float force = 5f;
private MonkeyBar mBar;
public bool enableCTRL=true;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		mBar=FindObjectOfType<MonkeyBar>();
	}
	
	// Update is called once per frame
	void Update () {
	if(enableCTRL == true){
	anim.SetBool("BallForm",true);
	this.GetComponent<Collider2D>().enabled = false;
	
		if (Input.GetKey (KeyCode.D)){
			//transform.position+= new Vector3(speed * Time.deltaTime, 0.0f,0.0f);
			GetComponent<Rigidbody2D>().AddForce(transform.right * force);
		} else if (Input.GetKey (KeyCode.A)){
			//moving.y=-1f;
			//transform.position-= new Vector3(speed * Time.deltaTime, 0.0f,0.0f);
			GetComponent<Rigidbody2D>().AddForce(transform.right * -force);
		} 
		else if (Input.GetKey ("up")){
			//moving.y=-1f;
			//transform.position+= new Vector3(0.0f,speed * Time.deltaTime,0.0f);
			GetComponent<Rigidbody2D>().AddForce(transform.up * force);
		} else if (Input.GetKey ("down")){
			//moving.y=-1f;
			//transform.position-= new Vector3(0.0f,speed * Time.deltaTime,0.0f);
			GetComponent<Rigidbody2D>().AddForce(transform.up * -force);
		}
	
	}
	}
}
