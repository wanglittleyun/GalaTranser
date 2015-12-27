using UnityEngine;
using System.Collections;
/* Alarm Light
 * ===================
 * Alarm light is a red light, when it's off, it doesn't attect anything in the scene
 * when it's on, it'll change between low intensity and high intensity
 */

public class AlarmLight : MonoBehaviour {
	// the changing speed of the intensity of the alarm light
	public float fadeSpeed = 2.0f;
	// Maximum intensity of the alarm light
	public float highIntesity = 4.0f;
	// Minum intensity of the alarm light
	public float lowIntensity = 0.5f;
	// a threshold area of judging the state
	public float changeMargin = 0.2f;
	// if the alarm light is on
	public bool alarmOn;
	// current target intensity, should be minintensity or maxintensity
	float targetIntensity;
	// alarm light object
	Light alaLight;
	// Use this for initialization
	void Start () {
		alaLight = gameObject.GetComponent<Light> ();
		alaLight.intensity = 0.0f;
		targetIntensity = highIntesity;
	}

	// check if we should alter the target intensity
	void checkTargetIntensity(){
		if (Mathf.Abs (targetIntensity - alaLight.intensity) < changeMargin) {
			if(targetIntensity == highIntesity)
				targetIntensity = lowIntensity;
			else targetIntensity = highIntesity;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (alarmOn) {
			alaLight.intensity = Mathf.Lerp (alaLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
			checkTargetIntensity ();
		} else {
			alaLight.intensity = Mathf.Lerp (alaLight.intensity, 0.0f, fadeSpeed * Time.deltaTime);
			targetIntensity = highIntesity;
		}
	}
}
