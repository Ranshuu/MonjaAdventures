using UnityEngine;
using System.Collections;

public class activateRotate : MonoBehaviour {
public RotateObject rotate;
	// Use this for initialization
	void Start () {
	//rotate=GetComponent<RotateObject>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
	if(other.tag == "Player"){
		rotate.normalRotate= true;

		}
	}
	void OnTriggerExit2D (Collider2D other){
	if(other.tag == "Player"){
		
			rotate.normalRotate= false;

	}

	}


}
