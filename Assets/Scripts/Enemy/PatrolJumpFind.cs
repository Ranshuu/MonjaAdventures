using UnityEngine;
using System.Collections;

public class PatrolJumpFind: MonoBehaviour {

	private PlayerNormalCont thePlayer;
	public float moveSpeed;
	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;
	
	//
	public bool facingAway;
	public bool followOnLookAway;
	//
	
	public Transform wallCheck;
	public Transform edgeCheck;
	public float wallCheckRadius;
	public float edgeCheckRadius;
	public LayerMask whatIsWall;
	public LayerMask whatIsEdge;
	private bool hittingWall;
	public bool hittingEdge;
	
	// Use this for initialization
	void Start () {
		thePlayer=FindObjectOfType<PlayerNormalCont>();
	}
	
	// Update is called once per frame
	void Update () {
		hittingWall= Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius,whatIsWall);
		hittingEdge= Physics2D.OverlapCircle(edgeCheck.position, edgeCheckRadius,whatIsEdge);
		
		if (!hittingWall && hittingEdge)
		{
		if(thePlayer.transform.position.x < transform.position.x)
		{transform.localScale = new Vector3(-1f,1f,1f);}
		if(thePlayer.transform.position.x > transform.position.x)
		{transform.localScale = new Vector3(1f,1f,1f);}
		
		playerInRange= Physics2D.OverlapCircle(transform.position,playerRange,playerLayer);
		//
		if(!followOnLookAway)
		{
			
			//
			if(playerInRange)
			{
				transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position,moveSpeed * Time.deltaTime);
				return;
				
			}
		}
		if ((thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x < 0)||(thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x > 0))
		{
			facingAway = true;
		} else {
			facingAway = false;
		}
		
		if(playerInRange && facingAway)
		{
			transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position,moveSpeed * Time.deltaTime);
			
		}
		
		}
	}
	
	void OnDrawGizmosSelected (){
		
		Gizmos.DrawSphere(transform.position, playerRange);
	}
}
