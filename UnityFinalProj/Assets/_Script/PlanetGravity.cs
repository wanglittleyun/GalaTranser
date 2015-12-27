using UnityEngine;
using System.Collections;

/* PlanetGravity
 * ===================
 * this script is bind to a planet
 * when player is getting too near to the planet, it'll receive a drag force form the player to the planet
 * this force will geting stronger when the player is nearer to the planet
 */
public class PlanetGravity : MonoBehaviour {
	// player
	public GameObject player;
	// the power of distance
	public float Power_distance = 2.0f; 
	// the force when distance is 1
	public float forceMagnitude = 100000.0f;
	// a constant flag to let the alarm and warning system know which
	// planet if draging the space ship
	public int planet_flag;
	// the warning script binded to the player
	// used to inform player that their space ship is caught by a planet
	warning warnship;
	// to see if the planet is going to drag the player
	bool inSight;
	// Use this for initialization
	void Start () {
		inSight = false;
		warnship = player.GetComponent<warning> ();
	}
	
	// Update is called once per frame
	void Update () {
		// if the player is too near to the planet, the planet will add a force to the space ship
		if (inSight) {
			Vector3 force = (transform.position - player.transform.position) * forceMagnitude
				/ Mathf.Pow (Vector3.Magnitude (transform.position - player.transform.position), Power_distance);
			player.GetComponent<Rigidbody> ().AddForce (force);

		}
	}
	//change the state when player enter the range
	void OnTriggerEnter(Collider other){

		if (other.tag == Tags.Player) {
			warnship.gravity_warn(transform.position, planet_flag);
//			Debug.Log ("OnTrigger");
			inSight = true;
		}
	}
	// change the state when palyer leave the range
	void OnTriggerExit(Collider other){

		if (other.tag == Tags.Player) {
			warnship.gravity_escape(planet_flag);
//			Debug.Log ("Exit trigger");
			inSight = false;
		}
	}

}
