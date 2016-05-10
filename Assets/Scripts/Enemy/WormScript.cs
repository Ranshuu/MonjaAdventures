using UnityEngine;
using System.Collections;

public class WormScript : MonoBehaviour {
private Animator anim;
	// Use this for initialization
	void Start () {
	anim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
	if(other.gameObject.tag == "Player"){
			StartCoroutine(Damaged());

		}
	}

	IEnumerator Damaged(){

		anim.SetBool("hurtByPlayer",true);
		yield return new WaitForSeconds(0.5f);
		anim.SetBool("hurtByPlayer",false);

	}
}
