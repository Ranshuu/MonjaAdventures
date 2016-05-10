using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {
public float smooth = 500f;
public float targetAngles=90;
public bool normalRotate;
public bool continousRotate;
public bool counterClockWise;
public Quaternion curRot;
public float timeLeft=2f;
public bool executeTime;

public Quaternion oldRotation;
public Quaternion newRotation;


	// Use this for initialization
	void Start () {
	curRot = this.transform.rotation;
	}

	// Update is called once per frame
	void Update () {
	if(continousRotate == true){
	//script to rotate objects continously//
		
	if(counterClockWise == true){
		transform.Rotate(0,0,smooth* -Time.deltaTime); //anti-clockwise
	}else
	{
	transform.Rotate(0,0,smooth* -Time.deltaTime); // clockwise
		}
	}
	if(executeTime == true){
	timeLeft -= Time.deltaTime;

	}
		if(normalRotate == true  ){
		executeTime = true;
		//transform.Rotate(0,0,targetAngles);
		float tiltAroundX = Input.GetAxis("Vertical") * targetAngles;
		float tiltAroundZ = Input.GetAxis("Horizontal") * targetAngles;
		Quaternion target = Quaternion.Euler(0,0,tiltAroundZ);
		transform.rotation=Quaternion.Slerp(transform.rotation,target,Time.deltaTime * smooth);
		//GetComponent<Rigidbody2D>().velocity=Vector2.zero;

		}
		if(timeLeft<0){

			//closeWait();
			this.transform.rotation=curRot;
			/*oldRotation = this.transform.rotation;
			newRotation= new Quaternion(oldRotation.x ,oldRotation.y,oldRotation.z - 60,0);
			this.transform.rotation = Quaternion.Lerp(oldRotation,newRotation,Time.deltaTime * smooth);*/
			timeLeft=2f;
			executeTime = false;
		}
	}


	}


