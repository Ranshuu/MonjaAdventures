using UnityEngine;
using System.Collections;

public class StomperDamage : MonoBehaviour {
	
	public int damageToGive;
	private ProjectileCollisionCheck projectileCol;
	public float bounceOnEnemy;
	private EnemyHealthManager enemy;
	private Color blinkHit;
	private int n;
	private PlayerNormalCont player;
	
	private Rigidbody2D myrigidbody2D;
	// Use this for initialization
	void Start () {
		//myrigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
		player=FindObjectOfType<PlayerNormalCont>();
		projectileCol= FindObjectOfType<ProjectileCollisionCheck>();
		//enemy= FindObjectOfType<EnemyHealthManager>();
		//blinkHit=enemy.renderer.material.color;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//player.rigidbody2D.velocity=new Vector2(player.rigidbody2D.velocity.x,bounceOnEnemy);
		if(other.gameObject.layer == LayerMask.NameToLayer ("Enemy") && HealthManager.invisible == false){
			player.GetComponent<Rigidbody2D>().velocity=new Vector2(player.GetComponent<Rigidbody2D>().velocity.x,bounceOnEnemy);
			Debug.Log("triggered stomper");
			enemy = other.GetComponent<EnemyHealthManager>();
			blinkHit=enemy.GetComponent<Renderer>().material.color;
			StartCoroutine(blinkOnHit());
			
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
			}
		/*if(other.tag == "Enemy" && HealthManager.invisible == false )
		{Debug.Log ("enemy hit");
		enemy = other.GetComponent<EnemyHealthManager>();
		blinkHit=enemy.renderer.material.color;
		StartCoroutine(blinkOnHit());}
		
		other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
		myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x,bounceOnEnemy);*/
		
		
	}
	
	
	IEnumerator blinkOnHit(){
		for(int n = 0; n < 5; n++)
		{			enemy.GetComponent<Renderer>().material.color=Color.red;
			yield return new WaitForSeconds(.1f);
			enemy.GetComponent<Renderer>().material.color=blinkHit;
			yield return new WaitForSeconds(.1f);
		}
		
		
	}
}