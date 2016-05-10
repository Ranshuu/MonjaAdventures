using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
	public int startingLives;
	private int lifeCounter;
	private Text theText;
	public GameObject gameOverScreen;
	public PlayerNormalCont player;
	private AudioSource[] allAudioSources ;
	//public string mainMenu;
	//public float waitAfterGameOver;
	
	// Use this for initialization
	void Start () {
		theText = GetComponent<Text>();
		lifeCounter = startingLives;
		//lifeCounter= PlayerPrefs.GetInt("PlayerCurrentLives");
		player=FindObjectOfType<PlayerNormalCont>();
		allAudioSources =FindObjectsOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(lifeCounter < 0)
		{
			gameOverScreen.SetActive(true);
			player.gameObject.SetActive(false);
			/*for (int i = 0; i < allAudioSources.Length; i++)
			{
				allAudioSources[i].SetActive(false);
			}*/
			for (int i = 0; i < allAudioSources.Length; i++)
			{
				allAudioSources[i].enabled=false;
			}
		}
		
		theText.text = "x" + lifeCounter;
		
		/*if(gameOverScreen.activeSelf)
		{
			waitAfterGameOver -= Time.deltaTime;
		}
		
		if(waitAfterGameOver < 0)
		{
			Application.LoadLevel(mainMenu);
		}*/
		
	}
	
	public void GiveLife()
	{
		lifeCounter++;
		//PlayerPrefs.SetInt("PlayerCurrentLives",lifeCounter);
	}
	
	public void TakeLife()
	{
		lifeCounter--;
		//PlayerPrefs.SetInt("PlayerCurrentLives",lifeCounter);
	}
}
