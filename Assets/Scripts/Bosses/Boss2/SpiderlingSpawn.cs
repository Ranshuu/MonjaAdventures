using UnityEngine;
using System.Collections;

public class SpiderlingSpawn : MonoBehaviour {
public GameObject spawnPosition;
public GameObject Spiderling;
public bool spawning;
public int spawnLimit;
private Crawling crawlScript;

	// Use this for initialization
	void Start () {
		crawlScript = FindObjectOfType<Crawling>();
		spawnLimit = 0;
		InvokeRepeating("Spawn",3.0f,1.0f);
		//Instantiate(Spiderling,spawnPosition.transform.position,spawnPosition.transform.rotation);
	}

	// Update is called once per frame
	void Update () {
		//InvokeRepeating("Spawn",3.0f,1.0f);
		if(spawnLimit >3 &&  GameObject.FindGameObjectWithTag("Minions")==null  ){
		crawlScript.endSpawn = true;

		}

	}

	 void Spawn(){
		Debug.Log("Spawning...");
		//Instantiate(Spiderling,spawnPosition.transform.position,spawnPosition.transform.rotation);
	if(spawning== true && spawnLimit <= 3  ){

		Instantiate(Spiderling,spawnPosition.transform.position,spawnPosition.transform.rotation);
		spawnLimit++;
		}else{
			Debug.Log("Cancel Invoke");
				spawning =false;
				CancelInvoke ("Spawn");
			}
	}

}
