using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CnControls;
public class move : MonoBehaviour {
    //Vector3 forward;
    public Camera sCamera;  // Up Camera
    //public int flag=0;
    public float RotRate=1f; //旋轉率
    public float limitRotRate = 80; //限制旋轉度數
    public float limitSpeed =20;//最高速限
    public Scrollbar speedScrollbar;
    public Button stop_B;
    public Button turn_B;
    public Text vText;
    public int Hp;
    float speed;//飛行速度
    /*float forwordX;
    float forwordY;
    float forwordZ;*/
    //推進器
    public SU_Thruster[] thrusters;
    public GameObject player;
    GameController controller;
    
    public int Maxblood=100;
    

	// Use this for initialization
	void Start () {
        //GameController initialization
        controller = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameController>();
        //forward =transform.forward;
        //flag = 0;
        speedScrollbar.value = 0.5f;
        speed = 0;
        //flag = 0;
        /*forwordX=0f;
        forwordY = 0f;
        forwordZ = 0f;*/
        Hp = Maxblood;
        
	}
    
	// Update is called once per frame
	void Update () {
        //加減速度
        if (speedScrollbar.value > 0.5f )
        {
            //加速，直到上限
            if (speed + (speedScrollbar.value - 0.5f) * 0.2f > limitSpeed)
                speed = limitSpeed;
            else
            {
                speed += (speedScrollbar.value - 0.5f) * 0.8f;
                foreach (SU_Thruster _thruster in thrusters)
                {
                    _thruster.StartThruster();//噴火
                }
            }
                speedScrollbar.value -= 0.15f;//慢慢收回加速器
        }
        else if (speedScrollbar.value < 0.5f)
        {
            //減速，直到0
            if (speed - speedScrollbar.value * 0.2f < 0)
                speed = 0f;
            else
                speed -= 0.2f + speedScrollbar.value * 1f;//原本應該只有speedScrollbar.value * 0.2f，但會造成當拉到最下面不會減速的情況，所以多+0.2
            
            speedScrollbar.value += 0.15f;//慢慢收回加速器
            
        }
        else
        {
            foreach (SU_Thruster _thruster in thrusters)
            {
                _thruster.StopThruster();//停止噴火
            }
        }
        //移動
        transform.Translate(transform.forward * Time.deltaTime * speed*5);
        //顯示速度
        vText.text = "velocity:" +  speed ;
        
        //鏡頭位置
        sCamera.transform.position = transform.position - transform.forward * 5f + sCamera.transform.up * 0.8f;
        sCamera.transform.rotation = transform.rotation;

        //if (flag == 0) { 鍵盤控制
        if (Input.GetKey(KeyCode.A)) //&& transform.rotation.y > -(limitRotRate / 180))
        {
            transform.Rotate(new Vector3(0, -1, 0), RotRate); 
        }
        if (Input.GetKey(KeyCode.D)) //&& transform.rotation.y < (limitRotRate / 180))
        {
            transform.Rotate(new Vector3(0, 1, 0), RotRate);
        }
        if (Input.GetKey(KeyCode.W)) // && transform.rotation.x > -(limitRotRate / 180))
        {
            transform.Rotate(new Vector3(-1, 0, 0), RotRate);
        }
        if (Input.GetKey(KeyCode.S)) //&& transform.rotation.x < (limitRotRate / 180))
        {
            transform.Rotate(new Vector3(1, 0, 0), RotRate); 
        }
        //虛擬搖桿
         // Just use CnInputManager. instead of Input. and you're good to go
        var inputVector = new Vector3(CnInputManager.GetAxis("Horizontal"), 0, CnInputManager.GetAxis("Vertical"));
        Vector3 movementVector = inputVector;

        // If we have some input
        if (inputVector.sqrMagnitude > 0.1f)
        {//啟動搖桿
            //transform.forward = movementVector;

            if (CnInputManager.GetAxis("Vertical") > 0) //&& transform.rotation.x > -(limitRotRate / 180))
            {//向上
                transform.Rotate(new Vector3(-1, 0, 0), RotRate * CnInputManager.GetAxis("Vertical")*2);
            }
            if (CnInputManager.GetAxis("Vertical") < 0) // && transform.rotation.x < (limitRotRate / 180))
            {//向下
                transform.Rotate(new Vector3(1, 0, 0), RotRate * (-CnInputManager.GetAxis("Vertical")*2)); //print(transform.rotation.x);
            }
            if (CnInputManager.GetAxis("Horizontal") < 0) //&& transform.rotation.y  > -(limitRotRate / 180))
            {//向左
                transform.Rotate(new Vector3(0, -1, 0), RotRate*(-CnInputManager.GetAxis("Horizontal")*2));
            }
            if (CnInputManager.GetAxis("Horizontal") > 0) //&& transform.rotation.y  < (limitRotRate / 180))
            {//向右
                transform.Rotate(new Vector3(0, 1, 0), RotRate*CnInputManager.GetAxis("Horizontal")*2);
            }        
        }
        //慢慢回歸正面

           /* if (transform.rotation.x - forwordX > 0 && transform.rotation.x-forwordX < 0.5)
            {
                transform.Rotate(new Vector3(-1, 0, 0), RotRate * 0.2f);
            }
            if (transform.rotation.x - forwordX < 0 || transform.rotation.x - forwordX > 0.5)
            {
                transform.Rotate(new Vector3(1, 0, 0), RotRate * 0.2f);
            }
            if (transform.rotation.y - forwordY > 0 && transform.rotation.y - forwordY < 0.5)
            {
                transform.Rotate(new Vector3(0, -1, 0), RotRate * 0.2f);
            }
            if (transform.rotation.y - forwordY < 0 || transform.rotation.y - forwordY > 0.5)
            {
                transform.Rotate(new Vector3(0, 1, 0), RotRate * 0.2f);
            }
            if (transform.rotation.z - forwordZ < 0.5 && transform.rotation.z - forwordZ > 0)
            {
                transform.Rotate(new Vector3(0, 0, -1), RotRate * 0.4f);
            }
            if (transform.rotation.z - forwordZ < 0 || transform.rotation.z - forwordZ > 0.5)
            {
                transform.Rotate(new Vector3(0, 0, 1), RotRate * 0.4f);
            }*/
            //設置血量條
            controller.setblood(Hp,Maxblood);
            
            if (Hp <= 0)
            {
                
                controller.Explosion(transform.position);
                controller.gameover();//GG
                Destroy(player);
            }
            
	}
    /*public void turn_onClick()
    {
        
        //將目前方向設為前進中心方向
        sCamera.transform.position = transform.position - transform.forward * 5f + sCamera.transform.up * 0.8f; 
        sCamera.transform.rotation=transform.rotation;
        forwordX = transform.rotation.x;
        forwordY = transform.rotation.y;
        forwordZ = transform.rotation.z;
       
    }*/
    public void hit()
    {
        Hp -= 10;
    }
    // called when hit renew unit
	public void heal(){
		if (Hp <= 90)
			Hp += 10;
	}
	// Face to destination
	public void faceToDestination(){

	}
}
