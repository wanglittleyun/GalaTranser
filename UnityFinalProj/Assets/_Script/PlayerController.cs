using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float sight;	// a variable that decide distance that player can see
	float h,v;
	CoordinateMap map; //call function updateCoordinate to determine which object should be activited

	// Use this for initialization
	void Start () {

		map = GameObject.FindGameObjectWithTag (Tags.GameController).GetComponent<CoordinateMap> ();
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		transform.Translate (h,v,0);

		map.updateCoordinate (Tags.PlayerID, transform.position);
	}
}
