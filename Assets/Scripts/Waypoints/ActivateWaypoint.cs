using UnityEngine;
using System.Collections;

public class ActivateWaypoint : MonoBehaviour {
public WaypointWalker waypoint;
public GameObject player;
public GameObject puppet;
public bool destroyOnTrigger;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//if(activeWaypoint)
	//	{cameraPlayer.transform.position = new Vector3(puppet.transform.position.x + cameraPlayer.xOffset,puppet.transform.position.y + cameraPlayer.yOffset,puppet.transform.position.z -3.15f);}
		
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{	if (other.tag == "Player")
		{
		player.SetActive(false);
		puppet.SetActive(true);
		waypoint.enabled =true;
		Debug.Log ("Main Camera disabled");
		
		if(destroyOnTrigger){
		Destroy(this);
		}
		
		
			
		}
	
	}
}
