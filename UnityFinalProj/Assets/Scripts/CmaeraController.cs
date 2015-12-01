using UnityEngine;
using System.Collections;

public class CmaeraController : MonoBehaviour {
	GameObject m_camera;
	public int scalew=10;
	public int scaleh=3;
	public bool viewState;
	public Vector3 prePos;
	public Quaternion preRotation;
	// Use this for initialization
	void Start () {
		m_camera=GameObject.FindGameObjectWithTag("MainCamera");
		viewState=true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(viewState)
		{
			m_camera.transform.position=(this.transform.position-this.transform.forward*scalew+Vector3.up*scaleh);
			m_camera.transform.LookAt(this.transform.position);
		}
		
		
		
	
	}
}
