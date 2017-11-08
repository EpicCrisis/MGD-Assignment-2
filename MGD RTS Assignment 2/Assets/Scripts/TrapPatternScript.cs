using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPatternScript : MonoBehaviour
{

	public List<GameObject> trapObjects = new List<GameObject> ();

	public float trapDuration = 1f;
	public float trapDurationCounter = 0f;

	public int i = 0;

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckTrapAction ();
	}

	void CheckTrapAction ()
	{
		trapDurationCounter += Time.deltaTime;

		if (trapDurationCounter >= trapDuration) {

			trapDurationCounter = 0f;

			trapObjects [i].GetComponent<BoxCollider> ().enabled = false;
			trapObjects [i].GetComponentInChildren<ParticleSystem> ().Stop ();
			//trapObjects [i].SetActive (false);

			if (i != 0) {
				trapObjects [i - 1].GetComponent<BoxCollider> ().enabled = true;
				trapObjects [i - 1].GetComponentInChildren<ParticleSystem> ().Play ();
				//trapObjects [i - 1].SetActive (true);
			} else if (i == 0) {
				trapObjects [i + (trapObjects.Count - 1)].GetComponent<BoxCollider> ().enabled = true;
				trapObjects [i + (trapObjects.Count - 1)].GetComponentInChildren<ParticleSystem> ().Play ();
				//trapObjects [i + (trapObjects.Count - 1)].SetActive (true);
			}

			i++;

			i %= trapObjects.Count;

		} else {
			
			return;
		}
	}
}
