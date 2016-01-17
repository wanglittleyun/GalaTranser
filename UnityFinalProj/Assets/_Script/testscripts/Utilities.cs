using UnityEngine;
using System.Collections;
/*utilities that may use in other scripts*/
public class Utilities  {
	public static float MilePerHour_to_MeterPerSecond(float v){
		return (float)(v * 0.44704);
	}

	public static float MeterPerSecond_to_MilePerHour(float v){
		return (float)(v * 2.23693629);
	}

	/* Compare the sign of two float number
	 * Mathf.Sign returns 1 whereas the in put is 0 or larger than 0
	 * returns -1 when the input in smaller than 0*/
	public static bool SameSigh(float first, float second){
		if (Mathf.Sign (first) == Mathf.Sign (second))
			return true;
		else
			return false;
	}

	/* Used to normalize drag force add to the car*/
	public static float EvaluateNormPower(float normPower){
		if (normPower < 1)
			return 10 - normPower * 9;
		else
			return 1.9f - normPower * 0.9f;
	}


}
