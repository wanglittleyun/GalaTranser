using UnityEngine;
using System.Collections;

public class CoordinateMap : MonoBehaviour {
//	Vector3 PlayerCoordinate;
//	Vector3 Obtacle1Coordinate;
	Vector3 [] Coordinates;
	public GameObject obstacle1;
	float sight;

	// Use this for initialization
	void Start () {
		Coordinates = new Vector3[Tags.MaxID];
		Coordinates[Tags.PlayerID] = GameObject.FindGameObjectWithTag (Tags.Player).transform.position;
		Coordinates[Tags.Obstacle1ID] = obstacle1.transform.position;
		sight = GameObject.FindGameObjectWithTag (Tags.Player).GetComponent<PlayerController> ().sight;
//		PlayerCoordinate = GameObject.FindGameObjectWithTag (Tags.Player).transform.position;
//		Obtacle1Coordinate = GameObject.FindGameObjectWithTag (Tags.Obstacle).transform.position;
	}

	public void updateCoordinate(int flag, Vector3 currentPosition){

		switch (flag) {
		case Tags.PlayerID:
			Coordinates[Tags.PlayerID] = currentPosition;
			break;
		}

	}

	bool compareDistaceToSight(int flag){
		Vector3 temp = Coordinates [flag] - Coordinates [Tags.PlayerID];
		return temp.magnitude <= sight;
	}
	void monitorDistance(){
		obstacle1.SetActive( compareDistaceToSight (Tags.Obstacle1ID));
	}
	// Update is called once per frame
	void Update () {
		monitorDistance ();
		Debug.Log (Coordinates[Tags.PlayerID]);
	}
}
