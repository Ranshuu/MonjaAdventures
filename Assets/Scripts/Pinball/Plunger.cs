using UnityEngine;
using System.Collections;

public class Plunger : MonoBehaviour {
public KeyCode triggerInput;
public float triggerTimer=0;
public float maxTimer=3;
public float minTimer=0;
public float force=10f;
public float maxforce=10f;
public float forceUp;
public float maxforceUp=300f;
public bool stopTrigger=false;
public bool decreaseTimer=false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	if(decreaseTimer == true){
	if(triggerTimer >=0.1)
			triggerTimer -= Time.deltaTime;
	if(triggerTimer < 0.1 && triggerTimer >=0)
			decreaseTimer = false;
	}
	if(Input.GetKey(triggerInput) && triggerTimer <=maxTimer){

	triggerTimer += Time.deltaTime;
	force *= 0.5f;
	//GetComponent<Rigidbody2D>().AddForce(transform.up * -force);
	}
	if( Input.GetKey(triggerInput)){
	//transform.Translate(Vector3.down * (Time.deltaTime*force));
	GetComponent<Rigidbody2D>().AddForce(transform.up * -force);
	}
	
	
		if(Input.GetKey(triggerInput) && triggerTimer >=maxTimer){
			
			triggerTimer = maxTimer;
		
		}
		
		if (Input.GetKeyUp(triggerInput) )
		{
			force=maxforce;
			decreaseTimer=true;
			GetComponent<Rigidbody2D>().AddForce(transform.up * forceUp);
			//transform.Translate(Vector3.up * (Time.deltaTime*forceUp));
		
		}
	
	
	}
	
	void OnCollisionEnter2D(Collision2D other){
	if(other.gameObject.tag == "Pinball"){
	//GetComponent<Rigidbody2D>().isKinematic=true;
	}
	}
	
	
}
