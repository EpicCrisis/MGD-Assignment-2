using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectMoveScript : MonoBehaviour
{

	NavMeshAgent navMeshAgent;

	public Transform currentTarget;
	Transform lastKnownTarget;

	public bool isSelected = false;

	RTSControllerScript unitController;

	void Start ()
	{
		navMeshAgent = this.GetComponent<NavMeshAgent> ();

		unitController = FindObjectOfType<RTSControllerScript> ();

		StartCoroutine (RepathRoutine ());
	}

	void Update ()
	{
		
	}

	IEnumerator RepathRoutine ()
	{
		if (isSelected) {
			while (true) {
				yield return new WaitForSeconds (0.5f);
				navMeshAgent.SetDestination (currentTarget.position);
			}
		}
	}
}
