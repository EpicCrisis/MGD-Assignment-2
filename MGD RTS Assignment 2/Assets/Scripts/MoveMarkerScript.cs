using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class MoveMarkerScript : MonoBehaviour
{

	public float lifeTime = 3f;
	public float lifeTimeCounter = 0f;

	public float spinSpeed = 100f;

	void Start ()
	{
		
	}

	void Update ()
	{
		transform.Rotate (Vector3.forward * spinSpeed * Time.deltaTime, Space.Self);

		//CountLife ();
	}

	void CountLife ()
	{
		lifeTimeCounter += Time.deltaTime;

		if (lifeTimeCounter >= lifeTime) {
			
			gameObject.SetActive (false);

			lifeTimeCounter = 0f;
		}
	}
}
