using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {
    public GameObject Can; public GameObject StopCan;
	// Use this for initialization
	void Start () {
        StopCan.active = false;
        Can.active = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void stop_onClick()
    {
        StopCan.active = true;
        Time.timeScale = 0;//Application.LoadLevel("menuScene");

        Can.active = false;
    }

    public void menu_onClick()
    {
        Can.active = true;
        StopCan.active = true;
        Application.LoadLevel("menuScene");
    }

    public void continue_onClick()
    {
        Can.active = true;
        Time.timeScale = 1;
        StopCan.active = false;
    }
    public void exit_onClick()
    {
        
        Application.Quit();
    }
}
