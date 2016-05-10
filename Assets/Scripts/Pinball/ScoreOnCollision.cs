using UnityEngine;
using System.Collections;

public class ScoreOnCollision : MonoBehaviour {
	public int collisionpoints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag =="Player"){
			ScoreManager.AddPoints(collisionpoints);
		}
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		
		ScoreManager.AddPoints(collisionpoints);
		
	}
	
}
