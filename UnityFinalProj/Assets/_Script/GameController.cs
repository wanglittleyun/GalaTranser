using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CnControls;
public class GameController : MonoBehaviour {
    public GameObject explosionPrefab;
    public GameObject continB;
    //public GameObject exitB;
    public GameObject Can; public GameObject StopCan;
    public GameObject WinCan; public GameObject LoseCan;
    public Scrollbar blood;
    public Text BT;
	// Use this for initialization
	void Start () {
        LoseCan.active = false;
        WinCan.active = false;
        Time.timeScale = 1;
	}
	
	

    public void Explosion(Vector3 position) {
        Instantiate(explosionPrefab, position, Quaternion.identity);
        StartCoroutine(wait());
        //Application.LoadLevel(0);
    }
    IEnumerator wait() {
        
        yield return new WaitForSeconds(5);
    }
    public void setblood(int hp,int Maxblood)
    {
        BT.text=hp+" / "+Maxblood;
        
        blood.size = ((float)hp) / ((float)Maxblood);
        if(hp<=0)
            hp = 0;
    }
    public void gamewin()
    {
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("NowLevel") > PlayerPrefs.GetInt("CompletedLevel"))//設定已完成的關卡
            PlayerPrefs.SetInt("CompletedLevel", PlayerPrefs.GetInt("NowLevel"));
        if (PlayerPrefs.GetInt("CompletedLevel")==5)//如果全部過關
            Application.LoadLevel("finish");
        PlayerPrefs.SetInt("NowLevel", 0);
        WinCan.active = true;
        StopCan.active = false;
        continB.active = false;
        
    }
    public void gameover()
    {
        Time.timeScale = 0;
        LoseCan.active = true;
        StopCan.active = false;
        continB.active = false;
    }
}
