using UnityEngine;
using System.Collections;
/* The space ship may be influenced by the gravity provided by nearby planets
 * Player will be warned once the spce ship is captured by any planet, the alarm will stop
 * once the player exits.
 * ======================
 * the warning system contains 3 main aspects:
 * 1: the cross. 
 * 		if the space ship is captured by a planet, we'll display a cross right one the planet
 * 		so that player may distinguish which planet is influencing the ship.
 * 		the cross is a orange circle. it'll be removed once the player leave the influencial
 * 		zone of the current planet
 * 2: the light.
 * 		as long as the space ship is influenced by gravity form any planet, dispite of distance
 * 		and number, we will switch on an alarm light which consecutively switching between light
 * 		and dark.
 * 		the alarm light will be switched off only when the ship is not in gravity zone of any planet
 * 3: the sound.
 * 		we will displayer a alarm audio together with the alarm light.
 * 		the alarm audio will be switched on and switched of the same time the light is turn on/ off
 */
public class warning : MonoBehaviour {

	public GameObject Cross;	// the cross that show the ship is caught by the pointed planet
	public GameObject alarmLight;	//AlarmLight GameObject built in the scene
	ArrayList nodes;	//use to manage the marked planets
	AlarmLight light_script;	// AlarmLight script binded to the AlarmLight GameObject

	// Use this for initialization
	void Start () {
		nodes = new ArrayList ();
		light_script = alarmLight.GetComponent<AlarmLight> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gravity_warn(Vector3 position,int flag){
		//Debug.Log ("ship warn");
		light_script.alarmOn = true;
		GameObject clone = (GameObject)Instantiate (Cross, position, Quaternion.identity);
		clone.transform.localScale = new Vector3 (600, 600, 600);
		nodes.Add (new Node(clone, flag));
	}

	public void gravity_escape(int flag){
        //Debug.Log("hello world" + nodes.Count);
		for (int index = 0; index < nodes.Count; index ++) {
			if(((Node)nodes[index]).flag == flag){
				Destroy (((Node)nodes[index]).go);
				nodes.Remove (nodes[index]);
			}
		}
		//Debug.Log (nodes.Count);
		if (nodes.Count == 0) {
			light_script.alarmOn = false;
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