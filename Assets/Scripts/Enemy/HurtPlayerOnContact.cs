using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {
	public int damageToGive;
	public float damageTimeMax;
	private float damageTime=0;
	private PlayerNormalCont playercont;
	private Animator animator;
	private int damage;
	//public bool invisible;
	private Vector3 savePosition;
	private PlayerStatus playerStat;
	public bool poisonous;
	public bool paralyze;
	
	// Use this for initialization
	void Start () {
		playercont=FindObjectOfType<PlayerNormalCont>();
		animator = playercont.GetComponent<Animator>();
		damage=damageToGive;
		playerStat=FindObjectOfType<PlayerStatus>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//playercont=FindObjectOfType<PlayerNormalCont>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{	
		
		if(other.tag == "Player" && HealthManager.invisible == false )
		{ 	Debug.Log("player hurt");
			
			HealthManager.HurtPlayer(damageToGive);
			HealthManager.invisible = true;
			//			other.GetComponent<AudioSource>().Play();
			var player = other.GetComponent<PlayerNormalCont>();
			player.knockbackCount = player.knockbackLength;
			if(other.transform.position.x < this.transform.position.x)
				{player.knockfromright = true;
				}
				else{
				player.knockfromright = false;}

				StartCoroutine(Damaged());

				if(poisonous == true){

				playerStat.poisoned = true;
				}
				if(paralyze == true){

				playerStat.paralyzed = true;
				}
			}


		}
	
		
		



	
	
	IEnumerator Damaged(){
		Debug.Log ("damaged");
		
		//	playercont.rigidbody2D.velocity = new Vector2(0,0);
		//rigidbody2D.isKinematic=true;
		playercont.onHurt= true;
		yield return new WaitForSeconds(0.7f);
		playercont.onHurt= false;
	

	}
	
	}
	

