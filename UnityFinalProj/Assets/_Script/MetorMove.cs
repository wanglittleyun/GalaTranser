using UnityEngine;
using System.Collections;

public class MetorMove : MonoBehaviour {
	//maximum life time of metor
	//destory the gameobject after such time flag
	public int maxmumLifeTime = 20;
	
	// Use this for initialization
	void Start () {

		StartCoroutine (DestoryOnTime());

	}

	void Awake(){

	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (moveOrientation * moveSpeed);
	}

	IEnumerator DestoryOnTime(){
		yield return new WaitForSeconds (maxmumLifeTime);
		Destroy (gameObject);
	}
}
