using UnityEngine;
using System.Collections;
/* Renew
 * ======================
 * this script is bind to renew unit
 * renew unit is in the scene
 * when the player hit the trigger of the renew unit
 * it'll consume the renew unit and give the player extra health point
 */
public class Renew : MonoBehaviour {
	// player gameobject
	GameObject player;
	// move script binded on the player gameobject
	move movecs;
	// the green light component on the unit
	Light greenLight;
	// to see if the player his hitted the unit
	private bool hitflag = false;
	// when the player hit the trigger
	public float hitMaxIntensity = 5.0f;
	public float fadeSpeed = 0.8f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.Player);
		movecs = player.GetComponent<move> ();
		greenLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (hitflag) {
			//changeIntensity();
		//}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == Tags.Player){
			movecs.heal ();
			//hitflag = true;
			Destroy (gameObject);
		}
	}

	void changeIntensity(){
		greenLight.intensity = Mathf.Lerp (greenLight.intensity, hitMaxIntensity, fadeSpeed * Time.deltaTime);
	}
}
