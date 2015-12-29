using UnityEngine;
using System.Collections;

public class Menu_Main : MonoBehaviour {
    static bool firstEnter=true;
	// Use this for initialization
	void Start () {
        if (firstEnter)
        {//第一次進遊戲 初始化資料
            PlayerPrefs.SetInt("CompletedLevel", 0);
            PlayerPrefs.SetInt("NowLevel", 0);
            firstEnter = false;
        }
	}
	
	
    public void LoadGame()
    {
        Application.LoadLevel("select_level");
    }
    public void about()
    {

        Application.LoadLevel("about");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void back_Main()
    {
        Application.LoadLevel(0);
    }
}
