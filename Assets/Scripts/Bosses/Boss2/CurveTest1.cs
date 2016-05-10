using UnityEngine;
using System.Collections;

public class CurveTest1 : MonoBehaviour {
private Vector3 targetPos;
private GameObject player;
public float upForce=10f;
public float jumpSpeed=5;
public bool jumpEnabled ;
public bool targetLock;
public StatePatternEnemy2 statePattern;
void Start(){
player= GameObject.FindGameObjectWithTag("Player");
//targetPos = new Vector3 (player.transform.position.x,transform.position.y,0);
statePattern=FindObjectOfType<StatePatternEnemy2>();

}

void Update(){
if(jumpEnabled == true){
StartCoroutine (Waiting());
		
		}
}
IEnumerator TravelInCurve(Vector3 targetPos, Transform tr) {
		
 float t = 0f;
 float distance = Vector3.Distance(tr.position, targetPos);

 while(t < 1) {
      tr.position = Vector3.Lerp(tr.position, GetQuadraticCoordinates(t, tr.position + Vector3.up * upForce, Vector3.Lerp(tr.position, targetPos, 0.5f) + Vector3.up * (Vector3.Distance(tr.position, targetPos) / 2.0f), targetPos), t);
      t += Time.deltaTime / distance * jumpSpeed;
      yield return null;
 }
 if(t >=1 ){

 jumpEnabled = false;
 statePattern.currentState = statePattern.patrolState;
//yield return null;
 }
 }
     
     public Vector3  GetQuadraticCoordinates(float t, Vector3 p0, Vector3 c0, Vector3 p) 
     {
         return Mathf.Pow(1 - t, 2) * p0 + 2 * t * (1 - t) * c0 + Mathf.Pow(t, 2) * p;
     }

     IEnumerator Waiting(){
		yield return new WaitForSeconds(4f);
				if ( targetLock == true){
				targetPos = new Vector3 (player.transform.position.x,transform.position.y,0);
				//targetPos = player.transform.position;
				targetLock = false;
				}
		yield return new WaitForSeconds(0.5f);
		StartCoroutine (TravelInCurve( targetPos, this.transform));
     }
}
