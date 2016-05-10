using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {
	public float speed;
	public PlayerNormalCont player;
	
	private GameObject weapon_clone;
	public float rotationSpeed;
	//private HurtPlayerOnContact hurtPlayer;
	private Animator animator;
	public int damageToGive;
	private bool invisible;
	//	public HurtPlayerOnContact enemyObject;
	private ProjectileCollisionCheck projectilecheck;
	
	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerNormalCont>();
		if(player.transform.position.x <transform.position.x){
			speed =- speed;
			rotationSpeed = -rotationSpeed;}
		animator = player.GetComponent<Animator>();
		projectilecheck=FindObjectOfType<ProjectileCollisionCheck>();
		//		enemyObject=FindObjectOfType<HurtPlayerOnContact>();
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity= new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		
		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed; //determine how much speed object rotates
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{	Debug.Log ("weapon collide");
		
		
		/*	if(other.tag == "Player" )
			{	//----instant kill enemy code---
				//Instantiate(enemyDeathEffect,other.transform.position,other.transform.rotation);
				//Destroy(other.gameObject);
				//ScoreManager.AddPoints(pointsForKill);
				//HealthManager.HurtPlayer(damageToGive);
				//StartCoroutine(DamagedWeapon());
				Debug.Log("Player hurt");
			
			player.knockbackCount = player.knockbackLength;
			
			if(other.transform.position.x < transform.position.x)
			{player.knockfromright = true;
			}
			else{
				player.knockfromright = false;}
				
			
			}
			Instantiate(impactEffect, transform.position, transform.rotation);*/
		//	Destroy (gameObject);
		
		
	}
	//Destroy (gameObject,0.5f);
	
	IEnumerator DamagedWeapon(){
		Debug.Log ("Damage by weapon");
		yield return new WaitForSeconds(3f);
		
		
		
		
		
	}
	
}
