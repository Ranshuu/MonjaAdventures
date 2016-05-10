using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MPManager : MonoBehaviour {
	public int maxPlayerMP;
	public static int playerMP;
	//Text text;
	public Slider MPBar;
	public static bool invisible;
	private LevelManager levelManager;
	private LifeManager lifeSystem;
	private TimeManager theTime;
	public bool isDead;
	private Animator animator;
	private PlayerNormalCont player;
	// Use this for initialization
	void Start () {
		//text = GetComponent<Text>();
		MPBar=GetComponent<Slider>();
		playerMP = maxPlayerMP;
		levelManager = FindObjectOfType<LevelManager>();
		lifeSystem=FindObjectOfType<LifeManager>();
		isDead = false;
		theTime=FindObjectOfType<TimeManager>();
		player=FindObjectOfType<PlayerNormalCont>();
		animator=player.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(playerMP <= 0 && !isDead)
		{	playerMP=0;
			
			
		}
		
		//	text.text = "" + playerHealth;
		MPBar.value = playerMP;
		
	}
	
	public static void UseMagic(int MPCost)
	{ if(invisible == false){		
			playerMP -= MPCost;
		}
		
	}
	
	
	public void FullMP()
	{
		playerMP = maxPlayerMP;
		
	}
	
	
	
}
