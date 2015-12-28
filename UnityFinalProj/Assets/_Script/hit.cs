using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {
    move PlayerController;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        PlayerController = player.GetComponent<move>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Tags.Player)
        {
            Debug.Log("On Collision Enter");
            PlayerController.hit();
        }
    }
}
