using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject currentCheckpoint;
	private PlayerNormalCont player;
	public GameObject DeathParticle;
	public GameObject LifeParticle;
	private Animator animator;
	private float gravityStore;
	public HealthManager healthManager;
	public int pointPenaltyOnDeath;
	public float respawnDelay;
	private CameraController camera;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerNormalCont>();
		gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
		camera=FindObjectOfType<CameraController>();
		animator=player.GetComponent<Animator>();
		healthManager=FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void RespawnPlayer()
	{
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		HealthManager.invisible = false;
		player.onHurt = false;
		StartCoroutine("RespawnPlayerCo");
		
	}
	
	public void LoadNextLevel(){
		Debug.Log ("New Level Load");
		Application.LoadLevel (Application.loadedLevel + 1);
		
	}
	
	public void GameOver(){
		Debug.Log ("Player dies");
		Application.LoadLevel ("Game Over");
	}
	
	public IEnumerator RespawnPlayerCo(){
		
		Instantiate (DeathParticle, player.transform.position, player.transform.rotation);

		player.gameObject.SetActive(false);
		player.GetComponent<Renderer>().enabled = false;
		camera.isFollowing = false;
		
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		
		//Respawning
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);
		//player.rigidbody2D.gravityScale = gravityStore;
		player.GetComponent<Rigidbody2D>().gravityScale=2.5f;
		player.knockbackCount=0;
		//player.enabled = true;
		player.gameObject.SetActive(true);
		player.GetComponent<Renderer>().enabled = true;
		healthManager.FullHealth();
		healthManager.isDead = false;
		animator.Play("MonjaIdle");
		player.transform.position = currentCheckpoint.transform.position;
		camera.isFollowing= true;
		Instantiate(LifeParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
