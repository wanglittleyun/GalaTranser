using UnityEngine;
using System.Collections;

public class warning : MonoBehaviour {
	public Camera camera;

	public Texture2D cross;//when we are catched by a planet, we will render this texture in it's place
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){

	}

	public void gravity_warn(Vector3 planet_world_coor, int flag){
		Vector3 window_vec = camera.WorldToScreenPoint (planet_world_coor);
		Rect rect = new Rect (new Vector2 (window_vec.x, window_vec.y), new Vector2(20.0f,20.0f));
		GUI.DrawTexture (rect,cross);
	}
}