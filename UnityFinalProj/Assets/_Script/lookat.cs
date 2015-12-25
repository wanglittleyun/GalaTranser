using UnityEngine;
using System.Collections;

public class lookat : MonoBehaviour {
	public GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag (Tags.Player);
	}
	
	// Update is called once per frame
	void Update () {
//		transform.LookAt (Player);
		gameObject.transform.LookAt (Player.transform.position);
		//gameObject.transform.Rotate (transform.up*Time.deltaTime * 1000);
	}
}
