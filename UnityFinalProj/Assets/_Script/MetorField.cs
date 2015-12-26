using UnityEngine;
using System.Collections;

public class MetorField : MonoBehaviour {

	public GameObject[] Metors;
	public float density;
	public float range;
	public const int maxNumber = 1000;
	public const float MIN_DISTANCE = 10.0f;
	ArrayList coordinates;

	// Use this for initialization
	void Start () {
		coordinates = new ArrayList ();
		generateMetors ();
	}

	void generateMetors(){
		int numbers = (int)(density * maxNumber);
		for (int index = 0; index < numbers; index++) {
			Debug.Log ("start to generate Coordinates");
			Vector3 pos = new Vector3(transform.position.x - range,
			                          Random.Range (transform.position.y - range, transform.position.y+range),
			                          Random.Range (transform.position.z - range, transform.position.z+range));
			if(!checkCollison(pos)){
				Debug.Log ("Ready to Instantiate new Object");
				coordinates.Add(pos);
				int flag = Random.Range(0,7);
				GameObject clone = (GameObject)Instantiate(Metors[flag], pos, Quaternion.identity);
				Rigidbody rg = clone.GetComponent<Rigidbody>();
				rg.AddForce(10000000.0f * transform.right);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	//check if the newly generated position is too near to other generated positions
	//return true if it's too near
	//when get true as a result, this newly generated position will be abandoned
	bool checkCollison(Vector3 pos){
		foreach (Vector3 oldPos in coordinates) 
			if (checkCollison (oldPos, pos))
				return true;
		return false;
	}
	//check if the newly generated position is too near to another position
	//return true if it's too near
	bool checkCollison(Vector3 pos1, Vector3 pos2){
		if (Vector3.Magnitude (pos1 - pos2) < MIN_DISTANCE)
			return true;
		return false;
	}
}
