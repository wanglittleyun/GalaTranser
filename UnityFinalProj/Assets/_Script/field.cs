using UnityEngine;
using System.Collections;

public class field : MonoBehaviour {
    public GameObject player;
    public float distance=500.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(player.transform.position.z - transform.position.z) < distance)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject go = transform.GetChild(i).gameObject;//子物件激活
                go.SetActive(true);
            }
            //gameObject.SetActive(true);
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject go = transform.GetChild(i).gameObject;
                go.SetActive(false);
            }
        }
	}
}
