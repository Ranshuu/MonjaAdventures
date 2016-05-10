using UnityEngine;
using System.Collections;

public class ProjectileCollisionCheck : MonoBehaviour {
	public bool invisible;
	private PlayerNormalCont player;
	private EnemyWeapon enemyWeapon;
	private Animator animator;
	public Vector2 savePosition;
	public GameObject impactEffect;
	// Use this for initialization
	void Start () {
		player= FindObjectOfType<PlayerNormalCont>();
		animator=player.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		player= FindObjectOfType<PlayerNormalCont>();
		/*if(HealthManager.invisible == true){
		savePosition = transform.position;
		}*/
	}
	
	void OnTriggerEnter2D (Collider2D other){
		
		if(	other.gameObject.layer == LayerMask.NameToLayer("Projectiles") && invisible == false){
			
			player.knockbackCount = player.knockbackLength;
			
			if(this.transform.position.x < other.transform.position.x)
			{player.knockfromright = true;
			}
			else{
				player.knockfromright = false;}
			
			enemyWeapon=other.GetComponent<EnemyWeapon>();
			invisible=true;
			HealthManager.HurtPlayer(enemyWeapon.damageToGive);
			Instantiate(impactEffect, transform.position, transform.rotation);
			//other.GetComponent<AudioSource>().Play();
			StartCoroutine(DamagedWeapon());
		}
		
		
		
		
		
		
		
		
		
	}
	
	IEnumerator DamagedWeapon(){
		
		
		HealthManager.invisible = true;
		player.onHurt= true;
		animator.SetBool("Hurt",true);
		gameObject.tag = "Players";
		yield return new WaitForSeconds(2f);
		gameObject.tag = "Player";
		animator.SetBool("Hurt",false);
		invisible=false;
		HealthManager.invisible = false;
		player.onHurt= false;
		
		
	}
}
