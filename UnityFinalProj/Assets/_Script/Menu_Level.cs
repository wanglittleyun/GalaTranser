using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu_Level : MonoBehaviour {
    //public static int CompletedLevel=1;
    //public static int NowLevel = 0;
    public Sprite PL0;
    public Sprite PL1;
    public Sprite PL2;
    public Sprite PL3;
    public Sprite PL4;
    public Sprite PL5;
    public Button BL1;
    public Button BL2;
    public Button BL3;
    public Button BL4;
    public Button BL5;
    public Button BL6;
    public Button BL7;
    public Button BL8;
    public Button BL9;
    public Button BL10;
	// Use this for initialization
	void Start () {
        setLock(); 
	}
	
    public void setLock()
    {
        if (PlayerPrefs.GetInt("CompletedLevel") > 0)
        {
            BL2.image.sprite = PL2;
            BL2.interactable = true;
        }
        else
        {
            BL2.image.sprite = PL0; BL2.interactable = false;
        }
        if (PlayerPrefs.GetInt("CompletedLevel") > 1)
        {
            BL3.interactable = true; BL3.image.sprite = PL3;
        }
        else
        {
            BL3.image.sprite = PL0; BL3.interactable = false;
        }
        if (PlayerPrefs.GetInt("CompletedLevel") > 2)
        {
            BL4.image.sprite = PL4; BL4.interactable = true;
        }
        else
        {
            BL4.image.sprite = PL0; BL4.interactable = false;
        }
        if (PlayerPrefs.GetInt("CompletedLevel") > 3)
        {
            BL5.image.sprite = PL5; BL5.interactable = true;
        }
        else
        {
            BL5.image.sprite = PL0; BL5.interactable = false;
        }
        //目前只到第五關
    }
    
    public void back_Main()
    {
        Application.LoadLevel(0);
    }
    public void task_1()
    {
        PlayerPrefs.SetInt("NowLevel", 1);
        Application.LoadLevel("task_1");
    }
    public void task_2()
    {
        PlayerPrefs.SetInt("NowLevel", 2); Application.LoadLevel("task_2");
    }
    public void task_3()
    {
        PlayerPrefs.SetInt("NowLevel", 3); Application.LoadLevel("task_3");
    }
    public void task_4()
    {
        PlayerPrefs.SetInt("NowLevel", 4); Application.LoadLevel("task_4");
    }
    public void task_5()
    {
        PlayerPrefs.SetInt("NowLevel", 5); Application.LoadLevel("task_5");
    }
}
