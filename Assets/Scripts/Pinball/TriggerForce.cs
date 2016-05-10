using UnityEngine;
using System.Collections;

public class TriggerForce : MonoBehaviour {
	public bool forceLeft;
	public bool forceUp;
	public bool forceDown;
	public bool forceRight;
	public float force ;
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	if(other.tag == "Player"){

	ApplyForce();
	}

	}

	void ApplyForce(){
		if (forceUp == true){
			Debug.Log ("Applying Force");
			//player.rigidbody2D.AddForce(new Vector2(0,force));
			player.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
		}
		if (forceDown == true){
			Debug.Log ("Applying Force");
			//player.rigidbody2D.AddForce(new Vector2(0,force));
			player.GetComponent<Rigidbody2D>().AddForce(transform.up * -force);
		}
		if (forceRight == true){
			Debug.Log ("Applying Force");
			//player.rigidbody2D.AddForce(new Vector2(0,force));
			player.GetComponent<Rigidbody2D>().AddForce(transform.right * force);
		}
		if (forceLeft == true){
			Debug.Log ("Applying Force");
			//player.rigidbody2D.AddForce(new Vector2(0,force));
			player.GetComponent<Rigidbody2D>().AddForce(transform.right * -force);
		}
	}
}
