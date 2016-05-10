using UnityEngine;
using System.Collections;

public class PauseMenuu : MonoBehaviour {
	public string levelSelect;
	public string mainMenu;
	public bool isPaused;
	public GameObject pauseMenuCanvas;
	private PlayerNormalCont player;
	// Use this for initialization
	void Start(){
		player=FindObjectOfType<PlayerNormalCont>();
		
	}
	void Update(){
		if (isPaused){
			pauseMenuCanvas.SetActive(true);
			Time.timeScale =0f;
			player.inputpauseenabled=false;
		}else{pauseMenuCanvas.SetActive(false);
			player.inputpauseenabled=true;}
		
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			isPaused = !isPaused;
			Time.timeScale = 1f;
		}
	}
	public void Resume(){
		isPaused = false;
	}
	
	public void LevelSelect(){
		Application.LoadLevel(levelSelect);
	}
	
	public void QuitGame(){
		Application.Quit();
	}
}
