using UnityEngine;
using System.Collections;

public class PatrolPinball : MonoBehaviour {
public float moveSpeed;
public LayerMask enemyRange ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmosSelected (){
		
		Gizmos.DrawSphere(transform.position, enemyRange);
	}
}
