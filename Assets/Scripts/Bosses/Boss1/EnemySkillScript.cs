using UnityEngine;
using System.Collections;

public class EnemySkillScript : MonoBehaviour {
private StatePatternEnemy enemy;
private GameObject player;
float speed;
Vector2 _direction;
public bool isReady;

	void Awake()
	{
		speed = 5f;
		isReady = false;

	}
	// Use this for initialization
	void Start () {
	enemy=GetComponent<StatePatternEnemy>();
	player=GameObject.FindGameObjectWithTag("Player");
	}

	public void SetDirection(Vector2 direction)
	{
		_direction = direction.normalized;
		isReady = true;

	}
	
	// Update is called once per frame
	void Update () {
			
		
		if(isReady)
		{

			Vector2 position = transform.position;
			position += _direction * speed * Time.deltaTime;
			transform.position = position;

		}else{Destroy(this);}
	}
}
