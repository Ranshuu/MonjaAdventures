using UnityEngine;
using System.Collections;

public class ActivateWaypoint1 : MonoBehaviour {
public WaypointPlayer waypoint;
public GameObject player;
public GameObject monjaAutoMove;
public bool destroyOnTrigger;
public bool activateAutoMove=false;
	// Use this for initialization
	void Start () {
	monjaAutoMove=GameObject.FindGameObjectWithTag("automove");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
	if(other.tag =="Player" ){
	activateAutoMove=true;
	player.SetActive(false);
	monjaAutoMove.SetActive(true);
	waypoint.enabled=true;
	Debug.Log("Main Camera disabled");
	
		if(destroyOnTrigger){
		Destroy(this);
			}
		}
	
	}
}
