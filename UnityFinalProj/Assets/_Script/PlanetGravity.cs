using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour {
	public GameObject player;
	public float Power_distance = 2.0f; 
	public float forceMagnitude = 100000.0f;
	public int planet_flag;
	warning warnship;
	bool inSight;
	// Use this for initialization
	void Start () {
		inSight = false;
		warnship = player.GetComponent<warning> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inSight) {
			Vector3 force = (transform.position - player.transform.position) * forceMagnitude
				/ Mathf.Pow (Vector3.Magnitude (transform.position - player.transform.position), Power_distance);
			player.GetComponent<Rigidbody> ().AddForce (force);

		}
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == Tags.Player) {
			warnship.gravity_warn(transform.position, planet_flag);
			Debug.Log ("OnTrigger");
			inSight = true;
		}
	}
	void OnTriggerExit(Collider other){

		if (other.tag == Tags.Player) {
			warnship.gravity_escape(planet_flag);
			Debug.Log ("Exit trigger");
			inSight = false;
		}
	}

}
