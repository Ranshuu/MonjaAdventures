using UnityEngine;
using System.Collections;

public class FlipperForce : MonoBehaviour {
	public float flipperforce = 5f;
	public bool forceLeft;
	public bool forceUp;
	public bool forceDown;
	public bool forceRight;
	public string buttonName = "Fire1";
	public float force ;
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton(buttonName))
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,flipperforce));
		}
		else
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,-flipperforce));
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{ if(Input.GetButton(buttonName))
		{
			ApplyForce();
		}
		else
		{
			
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
