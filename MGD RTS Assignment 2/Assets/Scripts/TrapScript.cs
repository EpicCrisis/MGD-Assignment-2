using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrapScript : MonoBehaviour
{
	public Transform returnPosition;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {

			Debug.Log ("PLAYER STEP ON TRAP");

			AudioManager.instance.Play ("Death");

			other.transform.position = returnPosition.position;

			other.GetComponent<NavMeshAgent> ().SetDestination (returnPosition.position);
		}
	}
}
