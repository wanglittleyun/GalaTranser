using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour {
	public GameObject player;
	public float Power_distance = 2.0f; 
	public float forceMagnitude = 100000.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 force = (transform.position - player.transform.position) * forceMagnitude
			/Mathf.Pow(Vector3.Magnitude(transform.position- player.transform.position),Power_distance);
		player.GetComponent<Rigidbody> ().AddForce (force);
	}
}
