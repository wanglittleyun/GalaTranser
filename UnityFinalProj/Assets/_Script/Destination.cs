using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {
    public GameObject light;
    int lightState = 0;
    GameController controller;
	// Use this for initialization
	void Start () {
        //GameController initialization
//		Debug.Log (Tags.test);
        controller = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (light.GetComponent<Light>().intensity > 0.2f && lightState == 0)
            light.GetComponent<Light>().intensity -= 0.1f;
        else if (light.GetComponent<Light>().intensity <= 0.2f && lightState == 0)
        {
            lightState = 1;
           // Debug.Log("change light state0");
        }
        if (light.GetComponent<Light>().intensity < 1.2f && lightState == 1)
            light.GetComponent<Light>().intensity += 0.1f;
        else if (light.GetComponent<Light>().intensity >= 1.2f && lightState == 1)
        {
            lightState = 0;
           /// Debug.Log("change light state");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player) {
            controller.gamewin();
            //Application.LoadLevel("menuScene");
        }
    }
}
