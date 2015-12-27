using UnityEngine;
using System.Collections;

public class warning : MonoBehaviour {

	public GameObject Cross;	// the cross that show the ship is caught by the pointed planet
	ArrayList nodes;	//use to manage the marked planets


	// Use this for initialization
	void Start () {
		nodes = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gravity_warn(Vector3 position,int flag){
//		Debug.Log ("ship warn");
		GameObject clone = (GameObject)Instantiate (Cross, position, Quaternion.identity);
		clone.transform.localScale = new Vector3 (600, 600, 600);
		nodes.Add (new Node(clone, flag));
	}

	public void gravity_escape(int flag){
		foreach (Node n in nodes) {
			if(n.flag == flag){
				Destroy(n.go);
				nodes.Remove(n);
			}
		}
	}
}

public class Node{
	public GameObject go;
	public int flag;
	public Node(GameObject go, int flag){
		this.go = go;
		this.flag = flag;
	}
}