using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleTriggerScript : MonoBehaviour
{

	public List<GameObject> switchToTriggerObstacle = new List<GameObject> ();

	public List<GameObject> switchToStep = new List<GameObject> ();

	StepSwitchScript stepScript;

	public bool isSpecialDoor = false;

	public List<GameObject> obstacleToCreate = new List<GameObject> ();

	void Start ()
	{
		StartCoroutine (CheckDoor ());
	}

	void Update ()
	{
		
	}

	void CheckSwitchToStep ()
	{
		if (switchToStep.Count == switchToTriggerObstacle.Count && switchToTriggerObstacle.Count != 0) {

			gameObject.SetActive (false);

			if (isSpecialDoor) {

				for (int i = 0; i < obstacleToCreate.Count; i++) {
					
					obstacleToCreate [i].SetActive (true);

				}
			} else {

				return;
			}

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
