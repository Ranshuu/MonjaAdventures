using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {
	
	public int damageToGive;
	private ProjectileCollisionCheck projectileCol;
	public float bounceOnEnemy;
	private EnemyHealthManager enemy;
	private Color blinkHit;
	private int n;
	
	private Rigidbody2D myrigidbody2D;
	private PlayerNormalCont player;
	// Use this for initialization
	void Start () {
		//myrigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
		projectileCol= FindObjectOfType<ProjectileCollisionCheck>();
		player=FindObjectOfType<PlayerNormalCont>();
		//enemy= FindObjectOfType<EnemyHealthManager>();
		//blinkHit=enemy.renderer.material.color;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
/*	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("triggered stomper");
		if(other.gameObject.layer == LayerMask.NameToLayer ("EnemyPinball")){
			enemy = other.GetComponent<EnemyHealthManager>();
			blinkHit=enemy.GetComponent<Renderer>().material.color;
	
			
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x,bounceOnEnemy);}
		
		
	}*/

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log("triggered stomper");
		if(other.gameObject.layer == LayerMask.NameToLayer ("EnemyPinball")){
			enemy = other.gameObject.GetComponent<EnemyHealthManager>();
			other.gameObject.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x,bounceOnEnemy);}
		
		
	}
	
	

}