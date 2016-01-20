using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {
    public GameObject Can; public GameObject StopCan;
    public GameObject WinCan; public GameObject LoseCan;
	// Use this for initialization
	void Start () {
        StopCan.active = false;
        Can.active = true;
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
        Application.LoadLevel("select_level");
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
    public void again_onClick()
    {
        Can.active = true;
        Time.timeScale = 1;
        StopCan.active = false; LoseCan.active = false;
        if (PlayerPrefs.GetInt("NowLevel")==1)
            Application.LoadLevel("level_1");
        else if (PlayerPrefs.GetInt("NowLevel") == 2)
            Application.LoadLevel("level_2");
        else if (PlayerPrefs.GetInt("NowLevel") == 3)
            Application.LoadLevel("level_3");
        else if (PlayerPrefs.GetInt("NowLevel") == 4)
            Application.LoadLevel("level_4");
        else if (PlayerPrefs.GetInt("NowLevel") == 5)
            Application.LoadLevel("level_5");
    }
}
