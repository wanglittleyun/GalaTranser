using UnityEngine;
using System.Collections;
/* MetorTrigger
 * =====================
 * Metor trigger
 * to control if the metor generator is activated
 * when the player enter the trigger, it's activated
 * when the player leave the trigger, the generator stop to generate new meteors
 */
public class MetorTrigger : MonoBehaviour {
	//gameobject Metor field
	public GameObject Generator;
	//generator script
	MetorField controller;
	// Use this for initialization
	void Start () {
		controller = Generator.GetComponent<MetorField> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// when player enter the trigger field, set the relevant bool to true
	void OnTriggerEnter(Collider other){
		if (other.tag == Tags.Player) {
//			Debug.Log ("Player Enter");
			controller.activated = true;
		}
	}
	// when player leave the trigger field, set the relevant bool to false
	void OnTriggerExit(Collider other){
		if (other.tag == Tags.Player) {
//			Debug.Log ("Player Leaving");
			controller.activated = false;
		}
	}
}
