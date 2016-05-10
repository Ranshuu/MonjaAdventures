using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	
	public float startingTime;
	private float countingTime;
	private Text theText;
	private PauseMenuu thePauseMenu;
	private HealthManager theHealth;
	//	public GameObject gameOverScreen;
	//	public PlayerCont player;
	// Use this for initialization
	void Start () {
		countingTime=startingTime;
		theText = GetComponent<Text>();
		//player=FindObjectOfType<PlayerCont>();
		thePauseMenu = FindObjectOfType <PauseMenuu>();
		theHealth=FindObjectOfType<HealthManager>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(thePauseMenu.isPaused)
			return;
		countingTime -= Time.deltaTime;
		if(countingTime <= 0)
		{
			//gameOverScreen.SetActive(true);
			//player.gameObject.SetActive(false);
			theHealth.KillPlayer();
			
			
		}
		theText.text= "" + Mathf.Round(countingTime);
		
	}
	
	public void ResetTime()
	{
		countingTime = startingTime;
	}
}
