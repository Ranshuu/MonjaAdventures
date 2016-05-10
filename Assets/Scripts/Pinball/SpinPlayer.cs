using UnityEngine;
using System.Collections;

public class SpinPlayer : MonoBehaviour {
private PlayerNormalCont player;
private RotateObject rotateObject;
public GameObject sticky;
public bool activateSticky;
private Animator anim;
public float force=5f;
private Quaternion curRot;
	// Use this for initialization
	void Start () {
	player=FindObjectOfType<PlayerNormalCont>();
	anim=player.GetComponent<Animator>();
	rotateObject=FindObjectOfType<RotateObject>();
	curRot = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	if(activateSticky == true){
			player.transform.position = sticky.transform.position;
			player.transform.Rotate(0,0,rotateObject.smooth* -Time.deltaTime);
			if (Input.GetKey(KeyCode.D)){
			ForceRight();
			}
			if (Input.GetKey(KeyCode.A)){
			anim.SetBool("ClimbUp",false);
			}
	}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
		player.enableCTRL = false;
		activateSticky = true;
		anim.SetBool("ClimbUp",true);

		}

	}

	void ForceRight(){
		activateSticky =false;
		anim.SetBool("ClimbUp",false);

		player.transform.rotation=curRot;
		player.GetComponent<Rigidbody2D>().AddForce(transform.right * force);
		player.enableCTRL = true;

	}
}
