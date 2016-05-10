using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	public float moveSpeed;
	public bool moveRight;
	
	public Transform wallCheck;
	public Transform edgeCheck;
	public float wallCheckRadius;
	public float edgeCheckRadius;
	public LayerMask whatIsWall;
	public LayerMask whatIsEdge;
	private bool hittingWall;
	private bool hittingEdge;
	
	private Animator animator;

	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		var absVelX= Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		
		hittingWall= Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius,whatIsWall);
		hittingEdge= Physics2D.OverlapCircle(edgeCheck.position, edgeCheckRadius,whatIsEdge);
		
		if (hittingWall || !hittingEdge)
			moveRight =!moveRight;
		
		if (moveRight){
			transform.localScale = new Vector3(-1f,1f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);}
		else{
			transform.localScale = new Vector3(1f,1f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
