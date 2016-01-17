using UnityEngine;
using System.Collections;
/* New test movement control script*/
public class control : MonoBehaviour {
	/*mass center*/
	public Transform centerOfMass;
	//maximum speed, miles per hour
	public float topSpeed = 160.0f;
	//throttle
	public float throttle = 0.0f;
	//steer(truning left or right)
	private float steer = 0.0f;
	//rigidbody component of the player
	private Rigidbody rb;
	/* turning coefficient of the turning
	 * when the speed approach topSpeed, current turning coefficient will approach minTurn
	 * when the speed approach 0, current turining coefficient will approach maxTurn*/
	const float minTurn = 10;
	const float maxTurn = 15;

	// Use this for initialization
	void Start () {
		//initialization
		rb = GetComponent<Rigidbody> ();
		//rb.centerOfMass = centerOfMass.localPosition;
		// top speed is transferred to meters per second here
		topSpeed = Utilities.MilePerHour_to_MeterPerSecond (topSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		throttle = Input.GetAxis ("Vertical");
		steer = Input.GetAxis ("Horizontal");
	}
	// fixedupdate is called at the end of the pipeline
	void FixedUpdate(){
		Vector3 rv = transform.InverseTransformDirection (rb.velocity);
		ApplySteering (rv);
		ApplyThrottle ();
	}
	//use current speed to calculate current turning coefficient
	float SpeedToTurn(float speed){
		//threshold of minimum turning coefficient
		float threshold = topSpeed / 2;
		//if current speed is smaller than threshold, reutrn minTurn as current turning coefficient
		if (speed > threshold)
			return minTurn;
		//calculate current turning coeffcient when
		float speedIndex = 1 - (speed / threshold);
		return minTurn + speedIndex * (maxTurn - minTurn);
	}
	void ApplySteering(Vector3 rv){
		//turning radius
		float turnRadius = (float)(3.0 / Mathf.Sin ((90 - (steer * 30)) * Mathf.Deg2Rad));
		float currentTurningCoefficient = SpeedToTurn (rb.velocity.magnitude);
		//turning speed
		float turnSpeed = Mathf.Clamp (rv.z / turnRadius, -currentTurningCoefficient / 10, currentTurningCoefficient / 10);
		//when turning right, steer > 0, otherwise steer < 0
		transform.RotateAround (transform.position + transform.right * turnRadius * steer, transform.up, turnSpeed * Mathf.Rad2Deg * Time.deltaTime * steer);
	}
	//add and slow down the speed
	void ApplyThrottle(){
		rb.AddForce (transform.forward *20 * throttle * Time.deltaTime * rb.mass * 100);
	}
}
