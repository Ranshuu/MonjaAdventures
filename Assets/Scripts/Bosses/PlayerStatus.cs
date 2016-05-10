using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public int damageToGive=1;
	//public float damageTimeMax;
	//private float damageTime=0;
	private PlayerNormalCont playercont;
	private Animator animator;
	//private int damage;
	//public bool invisible;
	//private Vector3 savePosition;

	public bool poisoned;
	public float timePoisoned;
	public bool paralyzed;
	public float timeParalyzed;
	public bool hurt;
	public bool animPoison;
	public int playerDMG;
	public int playerminDMG;



	// Use this for initialization
	void Start () {
	playercont=FindObjectOfType<PlayerNormalCont>();
	animator = playercont.GetComponent<Animator>();

	}


	
	// Update is called once per frame
	void Update () {
		
	if(hurt == false && poisoned == true){
		playerminDMG = Mathf.RoundToInt(HealthManager.playerHealth * 0.7f);
		hurt = true;
		}
//	Debug.Log(playerminDMG);
		if(poisoned )
		{	
			if(timePoisoned <= 1f ){
				
				timePoisoned ++;
				playerDMG=Mathf.RoundToInt(HealthManager.playerHealth * 0.1f);


				
				InvokeRepeating("PoisonWait",3,5);

				//HealthManager.HurtPlayer(damageToGive);
		
				}
			
		}else{
			poisoned = false;
			timePoisoned = 0;
			animator.SetBool("Hurt",false);
			playercont.enableCTRL=true;
			}

		if(paralyzed && HealthManager.invisible == false)
		{	
			if(timeParalyzed <= 5f){
			playercont.moveSpeed = 1;
			timeParalyzed += Time.deltaTime;
			}else{
			playercont.moveSpeed = 3f;
			paralyzed = false;

			}
		}
	}

	public void PoisonWait(){
	if(	HealthManager.playerHealth >= playerminDMG )
		{	StartCoroutine(AnimatePoison());
			HealthManager.HurtPlayer(playerDMG);
			}
			else{
			poisoned = false;
			hurt = false;
		}
	
	}

	IEnumerator AnimatePoison(){
		animator.SetBool("Hurt",true);
			playercont.enableCTRL=false;
		yield return new WaitForSeconds(0.5f);
		animator.SetBool("Hurt",false);
			playercont.enableCTRL=true;

	}


}
