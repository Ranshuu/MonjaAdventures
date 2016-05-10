using UnityEngine;
using System.Collections;

public class PlayerCollisionCheck : MonoBehaviour {
	private PlayerNormalCont playerNormal;
	private PlayerBallController playerBall;
	private HurtEnemyOnContact hurtEnemy;
	private EnemyHealthManager enemy;
	//public PlayerNormalCont player;
	private Animator anim;
	public bool check=false;
	public bool ballOnGround;
	
	public KeyCode ballCharge;
	public GameObject chargeEffect;
	public GameObject finalchargeEffect;
	private GameObject instantiatedObj;
	private GameObject instantiatedObj2;
	private Transform target;
	public float ballChargeTimer=0;
	public float ballSpeed;
	public Vector3 ballVelocity;
	private Vector2 facingDir;
	private float linearDragDefault;
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Monja").transform;
		playerNormal=this.GetComponent<PlayerNormalCont>();
		playerBall=this.GetComponent<PlayerBallController>();
		hurtEnemy=this.GetComponent<HurtEnemyOnContact>();
		enemy=FindObjectOfType<EnemyHealthManager>();
		anim=this.GetComponent<Animator>();
		ballOnGround=false;
		linearDragDefault=GetComponent<Rigidbody2D>().drag;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		 ballVelocity = GetComponent<Rigidbody2D>().velocity;
		 facingDir = transform.localScale;
	if(playerNormal.inputpauseenabled == true && playerNormal.controlenabled == true){
	
		if(ballOnGround==false && Input.GetKeyDown(KeyCode.S) ){
			gameObject.GetComponent<Collider2D>().enabled=false;
			ballOnGround= true;
			Debug.Log("Pinball Mode");
			anim.SetBool("BallForm",true);
			anim.SetBool("Grounded",false);
			playerNormal.enabled=false;
			playerBall.enabled=true;
			this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.Interpolate;
			
		}

		if(ballOnGround==true && playerNormal.onHurt == true){
				this.GetComponent<Collider2D>().enabled=true;
				ballOnGround= false;
				anim.SetBool("BallForm",false);
				anim.SetBool("Grounded",true);
				playerNormal.enabled=true;
				playerBall.enabled=false;
				this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.None;
		}
		
		if(ballOnGround==true ){
		playerBall.force=25f; 
			if(Input.GetButtonDown("Ball")){
					StartCoroutine(startHoldTimer());
			
			}
			}else{playerBall.force=5f;} //slowing down movement on air
		
		
		if(ballOnGround==true && Input.GetKeyDown(KeyCode.W) ){
			this.GetComponent<Collider2D>().enabled=true;
			ballOnGround= false;
			anim.SetBool("BallForm",false);
			anim.SetBool("Grounded",true);
			playerNormal.enabled=true;
			playerBall.enabled=false;
			this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.None;
			
		}
		
//---------------- BallCharge Ability		
			if(anim.GetBool("BallCharge") == true){
				GetComponent<Rigidbody2D>().drag = 2.3f;
			//	HealthManager.invisible = true;
				gameObject.GetComponent<Collider2D>().enabled=false;
				ballOnGround= true;
				anim.SetBool("Grounded",false);
				playerNormal.enabled=false;
			//	playerBall.enabled=true;
				this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.Interpolate;
				if ( ballVelocity.x == 0 && check == true){
					check = false;
					Destroy(instantiatedObj2);
					anim.SetBool("BallCharge",false);
					ballChargeTimer = 0;
					gameObject.GetComponent<Collider2D>().enabled=true;
					ballOnGround= false;
					anim.SetBool("Grounded",true);
					playerNormal.enabled=true;
					playerBall.enabled=false;
					this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.None;
					Destroy(instantiatedObj2);
					GetComponent<Rigidbody2D>().drag = linearDragDefault;
					
				}
				if (Input.GetKeyDown(KeyCode.W)  ){
					check=false;
					gameObject.GetComponent<Collider2D>().enabled=true;
					ballOnGround= false;
					anim.SetBool("BallForm",false);
					anim.SetBool("Grounded",true);
					playerNormal.enabled=true;
				//	playerBall.enabled=false;
					this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.None;
					Destroy(instantiatedObj2);
					ballChargeTimer = 0 ;
					//anim.SetBool("Charging",false);
					anim.SetBool("BallCharge",false);
					GetComponent<Rigidbody2D>().drag = linearDragDefault;
				}
			} else{
				Destroy(instantiatedObj, 0.1f);
				Destroy (instantiatedObj2,0.1f);
				check = false;
				HealthManager.invisible = false;
				
			}
			
			if(Input.GetKey (ballCharge) && playerNormal.grounded == true && playerNormal.onHurt == false){
				if(MPManager.playerMP >= 50){
				
				finalchargeAnim();
				ballChargeTimer += Time.deltaTime;
				anim.SetBool("BallCharge",true);
				if(Input.GetKeyDown(ballCharge)){
					StartCoroutine (animHoldTimer());
					
				}
				}
			}
			
			if(Input.GetKeyUp (ballCharge) ){
				Destroy(instantiatedObj, 0.1f);
				//ballChargeTimer = ballChargeTimer - Time.deltaTime;
				
			}
			
			if(Input.GetKeyUp (ballCharge) && (ballChargeTimer>2)){
			if(MPManager.playerMP >= 50){
				HealthManager.invisible = true;
				playerNormal.onHurt=false;
				MPManager.UseMagic(50);
				check=true;
				if(facingDir.x == 1){
					GetComponent<Rigidbody2D>().velocity = new Vector3(ballSpeed,0,0);}
				else{
					GetComponent<Rigidbody2D>().velocity = new Vector3(-ballSpeed,0,0);
				}
				anim.SetBool("BallCharge",true);
				StartCoroutine(startHoldTimer());
				}
				
			}
			
			if(Input.GetKeyUp (ballCharge) && (ballChargeTimer<2)){
			check=false;
				ballChargeTimer = 0 ;
				//anim.SetBool("Charging",false);
				anim.SetBool("BallCharge",false);
				
				check=false;
				gameObject.GetComponent<Collider2D>().enabled=true;
				ballOnGround= false;
				anim.SetBool("BallForm",false);
				anim.SetBool("Grounded",true);
				playerNormal.enabled=true;
				//	playerBall.enabled=false;
				this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.None;
				Destroy(instantiatedObj2);
				ballChargeTimer = 0 ;
				//anim.SetBool("Charging",false);
				anim.SetBool("BallCharge",false);
				GetComponent<Rigidbody2D>().drag = linearDragDefault;
			}
//-------------- BallCharge Ability End	
	}
	}
	
	void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.layer == LayerMask.NameToLayer ("Enemy")  ){
			if(anim.GetBool("BallCharge")&& check==true){
				enemy.giveDamage(100);
			}else{
				ballChargeTimer = 0 ;
				//anim.SetBool("Charging",false);
				anim.SetBool("BallCharge",false);
			}
		}


	if(playerNormal.inputpauseenabled == true && playerNormal.controlenabled == true){
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground") && ballOnGround == false ){
			this.GetComponent<Collider2D>().enabled=true;
			anim.SetBool("BallForm",false);
			anim.SetBool("Grounded",true);
			playerNormal.enabled=true;
			playerBall.enabled=false;
			this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.None;
				
			
		}
		
		
		if(other.gameObject.layer == LayerMask.NameToLayer( "Pinball")){
			gameObject.GetComponent<Collider2D>().enabled=false;
			Debug.Log("Pinball Mode");

			anim.SetBool("BallForm",true);
			anim.SetBool("Grounded",false);
			playerNormal.enabled=false;
			playerBall.enabled=true;
			this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.Interpolate;
		}
	}
}

void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == ("Plunger")){
            GetComponent<Rigidbody2D>().mass = 0;
       		playerBall.enableCTRL=false;

		}
		if(other.gameObject.layer ==LayerMask.NameToLayer("Water")){
			GetComponent<Rigidbody2D>().gravityScale = 1.5f;

		}

}

void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == ("Plunger")){
		GetComponent<Rigidbody2D>().mass = 0.5f;
			playerBall.enableCTRL=true;
		}
		if(other.gameObject.tag == ("Water")){


		}

}

	IEnumerator startHoldTimer(){
		yield return new WaitForSeconds(1f);
		/*if ( ballVelocity.x == 0){
			//check = false;
			Destroy(instantiatedObj2);
			anim.SetBool("BallCharge",false);
			ballChargeTimer = 0;
			gameObject.collider2D.enabled=true;
			ballOnGround= false;
			anim.SetBool("Grounded",true);
			playerNormal.enabled=true;
			playerBall.enabled=false;
			this.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.None;
			
			
		}*/
	}
	
	IEnumerator animHoldTimer(){
		yield return new WaitForSeconds(0.3f);
		instantiatedObj = (GameObject) Instantiate(chargeEffect, transform.position, transform.rotation);
		finalchargeAnim();

	}
	
	void finalchargeAnim(){
		if(ballChargeTimer >= 2){
			if (GameObject.FindGameObjectWithTag("finalCharge")==null){
				Debug.Log("animation play");
				instantiatedObj2 = (GameObject) Instantiate(finalchargeEffect,target.position,target.rotation);
			}
		
		}
	}
	
}