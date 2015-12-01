using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public GameObject player;
    move PlayerController;
	Vector3 rotation;
	float rotateSpeed;
	float worldRotateSpeed;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.Player);
        PlayerController = player.GetComponent<move>();
		rotation = 	Random.onUnitSphere;
		rotateSpeed = Random.Range (0.2f,3.0f);
		worldRotateSpeed = Random.Range (-30.0f,50.0f);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (rotation * rotateSpeed);
		transform.RotateAround(Vector3.zero, Vector3.right, worldRotateSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Player) {
			Debug.Log ("On Collision Enter");
            PlayerController.hit();
		}
	}


}
