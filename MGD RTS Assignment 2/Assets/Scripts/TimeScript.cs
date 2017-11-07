using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
	Text timeText;

	int timeCounter = 0;

	void Start ()
	{
		timeText = GetComponent<Text> ();
	}

	void Update ()
	{
		if (!GameSettings.instance.isPaused) {

			timeCounter = (int)Time.timeSinceLevelLoad; 

			timeText.text = "TIME: " + timeCounter;
		}
	}
}
