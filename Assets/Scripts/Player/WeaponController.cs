using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	public float speed;
	private PlayerNormalCont player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	private GameObject weapon_clone;
	public int pointsForKill;
	public float rotationSpeed;
	public int damageToGive;
	
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerNormalCont>();
		if(player.transform.localScale.x <0)
			speed =- speed;
		rotationSpeed = -rotationSpeed;
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity= new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		
		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed; //determine how much speed object rotates
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.layer == LayerMask.NameToLayer ("Breakable") || other.CompareTag("Enemy") || other.gameObject.layer == LayerMask.NameToLayer ("Projectiles")){
			
			if(other.tag == "Enemy")
			{	//----instant kill enemy code---
				//Instantiate(enemyDeathEffect,other.transform.position,other.transform.rotation);
				//Destroy(other.gameObject);
				//ScoreManager.AddPoints(pointsForKill);
				
				other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
				Debug.Log("Projectile+Enemy Collision");
			}
			if(other.gameObject.layer == LayerMask.NameToLayer("Projectiles")){
				Destroy (other.gameObject);
			}
			Instantiate(impactEffect, transform.position, transform.rotation);
			//Destroy (gameObject);
			
			
		}
		//Destroy (gameObject,0.5f);
	}
	
	
}
