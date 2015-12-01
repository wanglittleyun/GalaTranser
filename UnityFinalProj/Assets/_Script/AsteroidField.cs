using UnityEngine;
using System.Collections;



public class AsteroidField : MonoBehaviour {

	public GameObject [] Asteroids;
	public float intensity;
	public float range;
	public const int maxNumber = 1000;
	public float rotateSpeed;
	public int rotateAxis;

	int index = 0;
	Vector3 [] coordinates;
	// Use this for initialization
	void Start () {
		coordinates = new Vector3[(int)(intensity * maxNumber) + 1];
		generateAsteroids ();
		rotates();
	}

	void generateAsteroids(){
		for (index = 0; index <(int)(intensity * maxNumber); index++) {
			Vector3 pos = new Vector3(Random.Range(transform.position.x-range,transform.position.x+range),
			                          Random.Range(transform.position.y-range,transform.position.y+range),
			                          Random.Range(transform.position.z-range,transform.position.z+range));
			if(checkCollision(pos)){
				coordinates[index+1] = pos;

				GameObject ast = Asteroids[Random.Range(0,7)];
				Instantiate(ast,
				            pos,
				            Random.rotation);
			}
		}
	}
	void rotates(){
		switch(rotateAxis){
		case 0:

			transform.Rotate(Vector3.up * Time.deltaTime);
			break;
		}
	}
	bool checkCollision(Vector3 other){
		for (int indexa = 0; indexa <= index; indexa ++) {
			if(coordinates[index] == other)
				return false;
		}
		return true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
