using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
//code for camera follow with deadzone//
	[SerializeField] Transform character;

	private Vector3 moveTemp;

	[SerializeField] float speed = 3;
	[SerializeField] float xDifference;
	[SerializeField] float yDifference;
	[SerializeField] float movementThreshold = 3;
	public bool deadZone=true;
//
	public float dampTime = 0.15f; 
	private Vector3 velocity = Vector3.zero;
	private PlayerNormalCont player;
	private GameObject autoMove;
	private ActivateWaypoint wayPlayer;
	
	public bool isFollowing;
	private bool transition2;
	private bool transition1;
	
	public float xOffset;
	public float yOffset;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerNormalCont>();
		autoMove=GameObject.FindGameObjectWithTag("automove");
		wayPlayer=FindObjectOfType<ActivateWaypoint>();
		transform.position=new Vector3(player.transform.position.x + xOffset,player.transform.position.y + yOffset,player.transform.position.z -3.15f);
	}
	
	// Update is called once per frame
	void Update () {
/*	if (wayPlayer.activateAutoMove == true)
	{
			if(isFollowing)
			{transform.position = new Vector3(autoMove.transform.position.x + xOffset,autoMove.transform.position.y + yOffset,autoMove.transform.position.z -3.15f);}
	
	}*/
		if(isFollowing)
		{	transform.position = new Vector3(player.transform.position.x + xOffset,player.transform.position.y + yOffset,player.transform.position.z -3.15f);}


		if(deadZone == true ){

			if(player.transform.position.x > transform.position.x)
			{
				xDifference = player.transform.position.x - transform.position.x;
			} else {

				xDifference = transform.position.x - player.transform.position.x;
			}

			if(player.transform.position.y > transform.position.y){
				yDifference = player.transform.position.y - transform.position.y;
			} else{

				yDifference = transform.position.y - player.transform.position.y;
			}

			if(xDifference >= movementThreshold || yDifference >= movementThreshold){
				moveTemp = player.transform.position;
				//moveTemp.x = player.transform.position.x + xOffset;
				moveTemp.y=player.transform.position.y + yOffset;
				moveTemp.z = -1;
				transform.position = Vector3.MoveTowards (transform.position, moveTemp, speed * Time.deltaTime);
				}

	}
	}
	
		
	IEnumerator PlayerFollow(){
		yield return new WaitForSeconds(3f);
		transition2 =true;
		//transform.position = new Vector3(player.transform.position.x + xOffset,player.transform.position.y + yOffset,player.transform.position.z -3.15f);
		if(transition2 == true){
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
			Vector3 delta = player.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			yield return new WaitForSeconds(1f);
			isFollowing = true;
		}
	}
}
