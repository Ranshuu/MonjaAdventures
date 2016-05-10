using UnityEngine;
using System.Collections;

public class CameraController1 : MonoBehaviour {
	//code for camera follow with deadzone//
	[SerializeField] Transform character;

	private Vector3 moveTemp;

	[SerializeField] float speed = 3;
	[SerializeField] float xDifference;
	[SerializeField] float yDifference;
	[SerializeField] float movementThreshold = 3;
	public bool deadZone;
//
	public float dampTime = 0.15f; 
	private Vector3 velocity = Vector3.zero;
	public GameObject player;
	
	
	public bool isFollowing;
	public bool deadZones;
	
	public float xOffset;
	public float yOffset;
	
	// Use this for initialization
	void Start () {
		deadZones = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing)
			{transform.position = new Vector3(player.transform.position.x + xOffset,player.transform.position.y + yOffset,player.transform.position.z -3.15f);}
		
		if(deadZones == true){
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
				moveTemp.z = -1;
				transform.position = Vector3.MoveTowards (transform.position, moveTemp, speed * Time.deltaTime);
				}

	}

	}

	
}
