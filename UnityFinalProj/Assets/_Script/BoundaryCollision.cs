using UnityEngine;
using System.Collections;

public class BoundaryCollision : MonoBehaviour {
	//player gameobject
	GameObject player;
	//move script binded on the player gameobject
	move movecs;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.Player);
		movecs = player.GetComponent<move> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Check Collision
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == Tags.Player) {
			//Debug.Log ("Collision Check");
			movecs.faceToDestination();
		}
	}
}
