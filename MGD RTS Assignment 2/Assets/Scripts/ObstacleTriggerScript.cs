using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ObstacleTriggerScript : MonoBehaviour
{

	public List<GameObject> switchToTriggerObstacle = new List<GameObject> ();

	public List<GameObject> switchToStep = new List<GameObject> ();

	StepSwitchScript stepScript;

	public List<GameObject> obstacleToCreate = new List<GameObject> ();

	public bool isSpecialDoor = false;

	public bool isWinTrigger = false;

	// Objects to bring in the win screen. //

	public GameObject restartPanel;

	public GameObject buttonPanel;

	public Text restartText;

	void Start ()
	{
		//StartCoroutine (CheckDoor ());
	}

	void Update ()
	{
		CheckSwitchToStep ();
	}

	void CheckSwitchToStep ()
	{
		/*
		if (switchToTriggerObstacle.Count == switchToStep.Count && switchToTriggerObstacle.Count != 0) {
			
			for (int i = 0; i < switchToStep.Count; i++) {
				
				if (switchToStep [i] != switchToTriggerObstacle [i]) {
					
					return;

				} else {

					gameObject.SetActive (false);

					if (isSpecialDoor) {

						for (int j = 0; j < obstacleToCreate.Count; j++) {

							obstacleToCreate [j].SetActive (true);

						}
					}

					if (isWinTrigger) {

						restartText.text = "YOU WIN";

						restartPanel.SetActive (true);

						gameSettings.isPaused = true;
					}
				}
			}
		}
		*/

		if (switchToTriggerObstacle.Count == switchToStep.Count) {

			for (int i = 0; i < switchToStep.Count; i++) {
			
				if (switchToTriggerObstacle.Contains (switchToStep [i]) && switchToTriggerObstacle.Count != 0) {
			
					AudioManager.instance.Play ("Door");

					gameObject.SetActive (false);

					if (isSpecialDoor) {

						for (int j = 0; j < obstacleToCreate.Count; j++) {
					
							obstacleToCreate [j].SetActive (true);

						}
					}

					if (isWinTrigger) {

						AudioManager.instance.Play ("Win");

						AudioManager.instance.Stop ("BGM");

						restartText.text = "YOU WIN";

						restartPanel.SetActive (true);

						buttonPanel.SetActive (false);

						GameSettings.instance.PauseGame (true);
					}

				} else {

					return;
				}
			}
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
