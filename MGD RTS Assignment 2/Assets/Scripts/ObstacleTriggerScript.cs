using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerScript : MonoBehaviour
{

	public List<GameObject> switchToTriggerObstacle = new List<GameObject> ();

	public List<GameObject> switchToStep = new List<GameObject> ();

	StepSwitchScript stepScript;

	void Start ()
	{
		StartCoroutine (CheckDoor ());
	}

	void Update ()
	{
		
	}

	void CheckSwitchToStep ()
	{
		if (switchToStep.Count == switchToTriggerObstacle.Count) {

			gameObject.SetActive (false);

		} else {

			return;
		}
	}

	IEnumerator CheckDoor ()
	{
		while (true) {

			yield return new WaitForSeconds (0.5f);

			CheckSwitchToStep ();
		}
	}
}
