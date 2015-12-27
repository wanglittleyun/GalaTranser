using UnityEngine;
using System.Collections;
/* Consecutively generate meteors form one Quad
 * the generated meteors will go the same direction as MetorField.transform.right*/
public class MetorField : MonoBehaviour {
	//Metor list
	public GameObject[] Metors;
	//the metor field is activated
	public bool activated;
	//the density of each wave
	public float density;
	//the range of the field
	public float range;
	//the time gap between two wave of metors
	public float waveTimeGap = 3.0f;
	//the maximum initial force of the metor
	public float maxSpeed = 100000000.0f;
	//the minmum initial force of the metor
	public float minSpeed = 10000000.0f;
	//max number of each wave
	public const int maxNumber = 1000;
	//The minum distance between each metor when first generated
	//min distance is used to avoid the collision when first generated
	public const float MIN_DISTANCE = 10.0f;
	//coordinate will be recorded to check collision when first generated
	//coordinates is used to avoid the collision when first generated
	//coordinates will be cleared before/after each wave was generated
	ArrayList coordinates;
	//a time count, cleared to zero after each wave was generated
	float timeflag;
	// Use this for initialization
	void Start () {
		coordinates = new ArrayList ();
		//generateMetors ();
	}

	void generateMetors(){
		int numbers = (int)(density * maxNumber);
		for (int index = 0; index < numbers; index++) {
//			Debug.Log ("start to generate Coordinates");
			Vector3 pos = new Vector3(transform.position.x - range,
			                          Random.Range (transform.position.y - range, transform.position.y+range),
			                          Random.Range (transform.position.z - range, transform.position.z+range));
			if(!checkCollison(pos)){
//				Debug.Log ("Ready to Instantiate new Object");
				coordinates.Add(pos);
				int flag = Random.Range(0,7);
				GameObject clone = (GameObject)Instantiate(Metors[flag], pos, Quaternion.identity);
				clone.transform.parent = gameObject.transform;
				Rigidbody rg = clone.GetComponent<Rigidbody>();
				float force = Random.Range (minSpeed, maxSpeed);
				rg.AddForce(force * transform.right);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		coordinates.Clear ();
		timeflag += Time.deltaTime;
		if (timeflag >= waveTimeGap && activated) {
			timeflag = 0;
			generateMetors ();
		}
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
