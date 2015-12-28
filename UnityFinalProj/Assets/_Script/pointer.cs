using UnityEngine;
using System.Collections;

public class pointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public GameObject target;//目標
    public GameObject player;//玩家
    public float speed=4;
    void Update()
    {
        Vector3 targetDir = target.transform.position - player.transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        //Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
