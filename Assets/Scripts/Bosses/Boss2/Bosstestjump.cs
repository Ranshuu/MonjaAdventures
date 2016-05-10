using UnityEngine;
using System.Collections;

public class Bosstestjump : MonoBehaviour {
	public Transform origin;
 public Transform goal;
 public float interval;
 private float starttime;
 private PlayerNormalCont player;
 public float trajectoryHeight = 5;
 Vector3 startPos ;
 Vector3 endPos ;
 public StatePatternEnemy2 stateScript;
 public bool activated;
 public float currentDuration;
 public float duration=3f;
	
 // Use this for initialization
 void Start () //Putting starttime in this position seems to enable resetting effect.
 {
     starttime = Time.time;
     player = FindObjectOfType<PlayerNormalCont>();
		endPos= player.transform.position;
		startPos = this.transform.position;
		stateScript = this.GetComponent<StatePatternEnemy2>();
 }
 
 // Update is called once per frame
 void Update () {
 if(activated == true){
	//	stateScript.enabled = false;
// startPos = this.transform.position;
    /* Vector3 center = (origin.position + goal.position) * 0.5F;
     center -= new Vector3(0, 0, 0);
     Vector3 riseRelCenter = origin.position - center;
     Vector3 setRelCenter = goal.position - center;
     float fracComplete = (Time.time - starttime) / interval;
     //transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
     //transform.position += center;
 
     if (transform.position == goal.position) 
     {
         transform.position = origin.position;
         gameObject.SetActive(false);
     }*/
  /*   float cTime = Time.time;

     Vector3 currentPos = Vector3.Lerp(startPos,endPos, cTime );
     currentPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
    transform.position =currentPos;*/

	
  	
 	}
 }

	

	
 }