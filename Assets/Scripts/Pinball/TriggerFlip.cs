using UnityEngine;
using System.Collections;

public class TriggerFlip : MonoBehaviour {
private WaypointPlayer wayPlayer;
public bool onFlip;
	// Use this for initialization
	void Start () {
	wayPlayer=FindObjectOfType<WaypointPlayer>();

	}
	
	// Update is called once per frame
	void Update () {
		wayPlayer.flip= onFlip;
	}

	void OnTriggerEnter2D(Collider2D other){
	onFlip = !onFlip;
	}
}
