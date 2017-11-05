using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectMoveScript : MonoBehaviour
{

	public NavMeshAgent navMeshAgent;

	public Transform currentTarget;
	Transform lastKnownTarget;

	RTSControllerScript unitController;

	void Start ()
	{
		navMeshAgent = GetComponent<NavMeshAgent> ();

		unitController = FindObjectOfType<RTSControllerScript> ();

		//StartCoroutine (RepathRoutine ());

		lastKnownTarget = currentTarget;
	}

	void Update ()
	{
		//CheckSelection ();
	}

	IEnumerator RepathRoutine ()
	{
		while (true) {
				
			yield return new WaitForSeconds (0.5f);
			navMeshAgent.SetDestination (currentTarget.position);
		}
	}

	void CheckSelection ()
	{
		for (int i = 0; i < unitController.units.Count; i++) {

			navMeshAgent.SetDestination (currentTarget.position);

		}
	}
}
