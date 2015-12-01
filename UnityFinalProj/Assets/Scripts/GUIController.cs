using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	public float Vertical;
	public float Horizontal;
	public bool runOrWalk;   //true:Run  false:Walk
	public bool GameStart;
	GameObject gun;
	GameObject body;
	GameObject tanks;
	GameObject gun_M;
	Transform firePos;
	GameObject m_camera;
	
	// Use this for initialization
	void Start () {		
		tanks =GameObject.FindGameObjectWithTag("Player");
		body = GameObject.Find("body");
		gun =GameObject.Find("Gun");
		gun_M=GameObject.Find("GunM");
		firePos=GameObject.Find("fireHole").transform;
		m_camera=GameObject.FindGameObjectWithTag("MainCamera");
		gun.GetComponent<CmaeraController>().prePos=transform.position;
		gun.GetComponent<CmaeraController>().preRotation=transform.rotation;
		
		
		runOrWalk = true;	
		GameStart=false;
		Vertical=0.0f;
		
	}	
	 void OnGUI() {		
			
				if(gun.GetComponent<CmaeraController>().viewState)
				{
					if (GUI.RepeatButton(new Rect(60, Screen.height-110, 50, 50), "up"))
					{
						Vector3 forward = body.transform.TransformDirection(Vector3.forward);
						tanks.GetComponent<CharacterController>().SimpleMove(forward*10);
						
					}
			        if (GUI.RepeatButton(new Rect(60, Screen.height-60, 50, 50), "down"))
			       	{
						Vector3 forward = body.transform.TransformDirection(Vector3.forward);
						tanks.GetComponent<CharacterController>().SimpleMove(-forward*10);
						
					}
					
					if (GUI.RepeatButton(new Rect(10, Screen.height-85, 50, 50), "left"))
					{
						body.transform.Rotate(new Vector3(0.0f,-0.5f,0.0f));
						
					}
					if (GUI.RepeatButton(new Rect(110, Screen.height-85, 50, 50), "right"))
			        {
						body.transform.Rotate(new Vector3(0.0f,0.5f,0.0f));		
						
					}
					
					if (GUI.RepeatButton(new Rect(Screen.width-110, Screen.height-110, 50, 50), "up"))
					{
						gun_M.transform.Rotate(new Vector3(-0.5f,0.0f,0.0f));		
					}
			        if (GUI.RepeatButton(new Rect(Screen.width-110, Screen.height-60, 50, 50), "down"))
			       	{
						gun_M.transform.Rotate(new Vector3(0.5f,0.0f,0.0f));        
					}
					
					if (GUI.RepeatButton(new Rect(Screen.width-160, Screen.height-85, 50, 50), "left"))
					{
						gun.transform.Rotate(new Vector3(0.0f,-0.5f,0.0f));	
					}
					if (GUI.RepeatButton(new Rect(Screen.width-60 , Screen.height-85, 50, 50), "right"))
			        {
						gun.transform.Rotate(new Vector3(0.0f,0.5f,0.0f));				
					}
					if (GUI.Button(new Rect(Screen.width-60 , 10, 50, 50), "fire") || Input.acceleration.x>0.0f)
			        {
						GameObject bullet = Instantiate(Resources.Load("Bullet"),firePos.position,firePos.rotation) as GameObject;
						bullet.GetComponent<Rigidbody>().AddForce(gun_M.transform.forward*3000);
					}
					
					if (GUI.Button(new Rect(10 , 10, 100, 50), "car view"))
			        {
						gun.GetComponent<CmaeraController>().viewState=false;
						transform.position=gun.GetComponent<CmaeraController>().prePos;
						transform.rotation=gun.GetComponent<CmaeraController>().preRotation;
					}
				}
				else
				{
					if (GUI.Button(new Rect(10 , 10, 100, 50), "top view"))
			        {
						gun.GetComponent<CmaeraController>().viewState=true;
						gun.GetComponent<CmaeraController>().prePos=transform.position;
						gun.GetComponent<CmaeraController>().preRotation=transform.rotation;
					}
					
				}
		}

}
