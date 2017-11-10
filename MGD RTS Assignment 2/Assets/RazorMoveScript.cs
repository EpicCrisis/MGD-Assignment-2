using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorMoveScript : MonoBehaviour
{
	public float moveSpeed = 10f;

	void Start ()
	{
		
	}

	void Update ()
	{
		MoveRazor ();
	}

	void MoveRazor ()
	{
		transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.layer == 15) {
			
			moveSpeed *= -1;
		}
	}
}
