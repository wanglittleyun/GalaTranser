using UnityEngine;
using System.Collections;

public class MetorMove : MonoBehaviour {
	Vector3 moveOrientation;
	float moveSpeed;
//	float rotateSpeed;

	public float minSpeed = 5.0f;
	public float maxSpeed = 20.0f;
//	public float minRotateSpeed = 5.0f;
//	public float maxRotateSpeed = 20.0f;
	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		moveOrientation = transform.forward;
		moveSpeed = Random.Range (minSpeed,maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (moveOrientation * moveSpeed);
	}

	public void set(Vector3 destination, float minSpeed, float maxSpeed){
		moveOrientation = Vector3.Normalize (destination);
		this.minSpeed = minSpeed;
		this.maxSpeed = maxSpeed;
		moveSpeed = Random.Range (minSpeed, maxSpeed);
	}

	public void set(Vector3 destination){
		moveOrientation = Vector3.Normalize (destination);
	}
}
