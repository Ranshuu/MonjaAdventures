using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	
	public PlayerNormalCont player;
	public GameObject enemy;
	public float spawnTime =3f;
	public Transform[] spawnPoints;
	public int waitingTime;
	private float timer;
	
	// Use this for initialization
	void Start () {
	//enemy= GameObject.FindGameObjectWithTag("MonsterCopter");
		//InvokeRepeating("Spawn",spawnTime,spawnTime);
	Spawn ();
		
	}
	
	void Spawn ()
	{	
		if (GameObject.FindGameObjectWithTag("MonsterCopter") == null)
		//if (GameObject.Find("Zombie(Clone)") == null)
		{ 
	Debug.Log ("Invoke Spawn");
	if(GameObject.Find("Monja")== null){
	return;
	}
	int spawnPointIndex = Random.Range (0, spawnPoints.Length);
	Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	
	}
		

	
	}
		
	
	// Update is called once per frame
	void Update () {
	timer += Time.deltaTime;
	if(timer> waitingTime){
		Spawn ();
		timer=0;
		}
		
	}
	
	
}
