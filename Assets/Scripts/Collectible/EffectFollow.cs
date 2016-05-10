using UnityEngine;
using System.Collections;

public class EffectFollow : MonoBehaviour {
private PlayerNormalCont player;
	// Use this for initialization
	void Start () {
	player=FindObjectOfType<PlayerNormalCont>();
	}
	
	// Update is called once per frame
	void Update () {
	this.transform.position = player.transform.position;
	}
}
