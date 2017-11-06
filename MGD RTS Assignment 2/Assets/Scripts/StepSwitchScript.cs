using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSwitchScript : MonoBehaviour
{
	[Header ("BLUE = 10, GREEN = 11, PINK = 12, RED = 13")]
	public int objectLayer = 0;

	ObstacleTriggerScript obstacleScript;

	void Start ()
	{
		obstacleScript = GetComponentInParent<ObstacleTriggerScript> ();
	}

	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.layer == objectLayer) {

			Debug.Log ("CORRECT COLOUR STEPS ON IT");

			obstacleScript.switchToStep.Add (this.gameObject);

		} else {

			return;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.layer == objectLayer) {

			obstacleScript.switchToStep.Remove (this.gameObject);

		} else {

			return;
		}
	}
}
