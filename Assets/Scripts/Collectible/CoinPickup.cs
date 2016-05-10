using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {
	
	public int pointsToAdd;
	
	public AudioSource coinSoundEffect;
	
	void OnTriggerEnter2D (Collider2D other)
	{	
		if(other.GetComponent<PlayerNormalCont>() == null){
			Debug.Log ("null");
			return;}
		if (other.CompareTag ("Player")) {
			ScoreManager.AddPoints (pointsToAdd);
			Destroy (gameObject);
		}
		
		//ScoreManager.AddPoints (pointsToAdd);
		
	//	coinSoundEffect.Play ();
		
		//Destroy (gameObject); 
		Debug.Log ("coin picked");
		
	}
}
