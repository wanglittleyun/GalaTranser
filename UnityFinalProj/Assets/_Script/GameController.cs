using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CnControls;
public class GameController : MonoBehaviour {
    public GameObject explosionPrefab;
    public GameObject loseT;
    public GameObject winT;
    public GameObject continB;
    //public GameObject exitB;
    public GameObject Can; public GameObject StopCan;
    public Scrollbar blood;
    public Text BT;
	// Use this for initialization
	void Start () {
        loseT.active = false;
        winT.active = false;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void Explosion(Vector3 position) {
        Instantiate(explosionPrefab, position, Quaternion.identity);
        StartCoroutine(wait());
        Application.LoadLevel(0);
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
        winT.active = true;
        StopCan.active = true;
        //Can.active = false;
        continB.active = false;
        
    }
    public void gameover()
    {
        Time.timeScale = 0;
        loseT.active = true;
        StopCan.active = true;
        //Can.active = false;
        continB.active = false;
    }
}
