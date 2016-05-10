using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	public int maxPlayerHealth;
	public static int playerHealth;
	//Text text;
	public Slider healthBar;
	public static bool invisible;
	private LevelManager levelManager;
	private LifeManager lifeSystem;
	private TimeManager theTime;
	public bool isDead;
	private Animator animator;
	private PlayerNormalCont player;
	//public static float damageTime=0f;
	//public static float damageTimeMax=1f;
	// Use this for initialization
	void Start () {
		//text = GetComponent<Text>();
		healthBar=GetComponent<Slider>();
		playerHealth = maxPlayerHealth;
		levelManager = FindObjectOfType<LevelManager>();
		lifeSystem=FindObjectOfType<LifeManager>();
		isDead = false;
		theTime=FindObjectOfType<TimeManager>();
		player=FindObjectOfType<PlayerNormalCont>();
		animator=player.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(playerHealth <= 0 && !isDead)
		{	playerHealth=0;
			levelManager.RespawnPlayer();
			lifeSystem.TakeLife();
			isDead = true;
			theTime.ResetTime();
			
		}
		
	//	text.text = "" + playerHealth;
	healthBar.value = playerHealth;
		
	}
	
	public static void HurtPlayer(int damageToGive)
	{ 	
		if(invisible == false ){		
			playerHealth -= damageToGive;
		}
		/*if(damageTime == 0 && invisible == false){
			invisible = true;
			playerHealth -= damageToGive;

		}
		if(damageTime > damageTimeMax  ){		
			invisible = false;
			damageTime = 0;
		}*/
		
	}
	
	
	public void FullHealth()
	{
		playerHealth = maxPlayerHealth;
		
	}
	
	public void KillPlayer()
	{
		playerHealth = 0;
		theTime.ResetTime();
	}
	
}
