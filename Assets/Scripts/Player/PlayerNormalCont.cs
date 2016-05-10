using UnityEngine;
using System.Collections;

public class PlayerNormalCont : MonoBehaviour {
	public float moveSpeed;
	public float moveVelocity;
	public float jumpHeight;
	
	public Transform groundCheck;
	public Transform edgeCheck;
	public Transform pinballCheck;
	public float groundCheckRadius;
	public float arenaCheckRadius;
	public float edgeCheckRadius;
	public LayerMask whatIsGround;
	public LayerMask whatIsPinball;
	public LayerMask whatIsEdge;
	
	public bool grounded;
	public bool pinball;
	private bool onEdge;
	
	public bool doubleJumped;
	
	private Animator anim;

	private WaypointPlayer waypointPlayer;
	
	public Transform firePoint;
	public GameObject astralSht;
	public float shotDelay;
	public float shotDelayCounter;
	
	public float knockback;
	public float knockbackCount;
	public float knockbackLength;
	public bool knockfromright;
	public bool inputpauseenabled;
	public bool controlenabled;
	public bool onHurt;
	private bool noKnock;
	
	private Rigidbody2D myRigidbody2D;
	private Collider2D myCollider2D;
	
	public bool enableCTRL=true;
	
	// Use this for initialization
	void Start () {
		
		onHurt=false;
		anim = GetComponent<Animator>();
		myRigidbody2D = GetComponent<Rigidbody2D>();
		myCollider2D = GetComponent<Collider2D>();

	}
	
	void FixedUpdate(){
		
		grounded= Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
		pinball= Physics2D.OverlapCircle(pinballCheck.position, arenaCheckRadius,whatIsPinball);
		onEdge = Physics2D.OverlapCircle(edgeCheck.position, edgeCheckRadius,whatIsEdge);
	
	}
	
	// Update is called once per frame
	void Update () {

		if(anim.GetBool("ClimbUp")== false && enableCTRL == true ){
			if(onHurt==true ){
			anim.SetBool("Hurt",true);

			if(knockbackCount <= 0)
			{	
				
				if(grounded){
				
					StartCoroutine(Damaged());
				
				}
				
			} else{
				
				
				if(knockfromright)
					
					myRigidbody2D.velocity = new Vector2(-knockback, knockback);
				
				if(!knockfromright)
					
					myRigidbody2D.velocity = new Vector2(knockback, knockback);
				
					knockbackCount -= Time.deltaTime;
				
			}
		}
	
			
		////////////
		
			if(onHurt == false ){
				GetComponent<Rigidbody2D>().isKinematic=false;
				anim.SetBool("Hurt",false);
				HealthManager.invisible = false;
				var absVelX= Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
				//var absVelY= Mathf.Abs (rigidbody2D.velocity.y);
				
			//	if(!pinball)
				
				if(pinball)
					
					grounded=false;
					anim.SetBool ("BallForm",pinball);
				
				if(grounded)
					
					doubleJumped = false;
					anim.SetBool ("Grounded",grounded);
				
				if(!onEdge){
					anim.SetBool ("Balance",true);
				}else{
					anim.SetBool ("Balance",false);
				}
				
				
				
				if(enableCTRL == true && inputpauseenabled == true){
					
					if(Input.GetButtonDown ("Jump") && grounded)
					{
						
						Jump ();
					}
					if(Input.GetButtonDown ("Jump") && !grounded && !doubleJumped )
					{
						Jump ();
						doubleJumped = true;
					}
					
					if( anim.GetBool("BallForm")==false){
						moveVelocity = 0f;
					}
					
					moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
	
				}
				
				
				
				if(knockbackCount <= 0)
				{	
					myRigidbody2D.velocity = new Vector2(moveVelocity, myRigidbody2D.velocity.y);
				
					
				} else{
					
					
					if(knockfromright)
						
						myRigidbody2D.velocity = new Vector2(-knockback, knockback);
						transform.localScale = new Vector3(-1f,1f,1f);
					
					if(!knockfromright)
						
						myRigidbody2D.velocity = new Vector2(knockback, knockback);
					
						transform.localScale = new Vector3(1f,1f,1f);
					
						knockbackCount -= Time.deltaTime;
					
					
				}
				
				
				anim.SetFloat ("Speed", absVelX );
				anim.SetFloat ("Fall", myRigidbody2D.velocity.y);
				
				if(myRigidbody2D.velocity.x > 0)
					transform.localScale = new Vector3(1f,1f,1f);

				else if (myRigidbody2D.velocity.x<0)
					transform.localScale = new Vector3(-1f,1f,1f);
				
				if (Input.GetButtonDown("Attack")){
					
					StartCoroutine(WaitForAttackToStop());
					
					}
				
				} 

				}
			}


   
    IEnumerator WaitForAttackToStop()
    {	Instantiate(astralSht,firePoint.position, firePoint.rotation);
	//anim.Play("MonjaAttack");
	yield return new WaitForSeconds(0.5f);
	anim.Play("MonjaIdle");
    }
    

    IEnumerator Damaged(){
	//myRigidbody2D.velocity = new Vector2(0,0);
	//GetComponent<Rigidbody2D>().isKinematic=true;
	//yield return new WaitForSeconds(2f);
		enableCTRL = false;
		Debug.Log ("damaged");
		GetComponent<Rigidbody2D>().isKinematic=true;
		anim.SetBool("Hurt",true);
		yield return new WaitForSeconds(0.7f);
		enableCTRL = true;
		onHurt= false;

    }
    
    
    public void Jump()
    {
		myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
	
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
		if(other.transform.tag == "MovingPlatform")
		{
			transform.parent = other.transform;
		}
		
	    }
	    void OnCollisionExit2D(Collision2D other)
	    {
		if(other.transform.tag == "MovingPlatform")
		{
			transform.parent = null;
		}
	
    }
    
	IEnumerator startHoldTimer(){
		yield return new WaitForSeconds(1f);
		
	}			    
}
				    
