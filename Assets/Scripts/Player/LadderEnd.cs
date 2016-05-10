using UnityEngine;
using System.Collections;

public class LadderEnd : MonoBehaviour {
private PlayerNormalCont player;
public Transform teleportPoint;
private LadderZone climbing;
private Animator anim;
	// Use this for initialization
	void Start () {
	player= FindObjectOfType<PlayerNormalCont>();
	climbing=FindObjectOfType<LadderZone>();
	anim= player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{	
		if(other.tag == "Player" && anim.GetBool("Climbing") == true)
		
		{other.transform.localPosition=teleportPoint.transform.localPosition;}
		
		//Destroy(other);
		//other.transform.position=new Vector3(0,0,0);
		
	}
	
}
