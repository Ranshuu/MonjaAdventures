using System.Collections;
 using UnityEngine;
 
 public class CurveTest : MonoBehaviour {
     
     public Vector3 targetPosition;
     public GameObject player;
     
     void Start(){
     player = GameObject.FindGameObjectWithTag("Player");
     targetPosition=player.transform.position;
     StartCoroutine (TravelInCurve(targetPosition, this.transform));
     }
     
	public IEnumerator TravelInCurve(Vector3 targetPos, Transform tr) {
 float t = 0f;
 float distance = Vector3.Distance(tr.position, targetPos);
 float speed = 5f;
 while(t < 1) {
      tr.position = Vector3.Lerp(tr.position, GetQuadraticCoordinates(t, tr.position + Vector3.up * 2f, Vector3.Lerp(tr.position, targetPos, 0.5f) + Vector3.up * (Vector3.Distance(tr.position, targetPos) / 2.0f), targetPos), t);
      t += Time.deltaTime / distance * speed;
      yield return null;
 }
 }
     
     public Vector3  GetQuadraticCoordinates(float t, Vector3 p0, Vector3 c0, Vector3 p1) 
     {
         return Mathf.Pow(1 - t, 2) *  p0 + 2 * t * (1 - t) * c0 + Mathf.Pow(t, 2) * p1;
     }
 }