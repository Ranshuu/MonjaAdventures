using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public bool Enable_CP_destroy = false;
	public LevelManager levelManager;
	public Animator animator;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		animator = GetComponent<Animator>();
		audio=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer()
	{
		Debug.Log ("Player Respawn");
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag ("Player"))
		{
			levelManager.currentCheckpoint = gameObject;
			animator.SetBool("CPactivated",true);
			audio.Play();
			if ( Enable_CP_destroy = true){
				GetComponent<Collider2D>().enabled = false;
			}
			Debug.Log ("Activated Checkpoint" + transform.position);
		}
	}
}
