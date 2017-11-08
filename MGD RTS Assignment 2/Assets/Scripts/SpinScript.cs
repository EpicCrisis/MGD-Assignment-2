using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{

	public float spinSpeed = 1f;

	void Start ()
	{
		
	}

	void Update ()
	{
		transform.Rotate (transform.up * spinSpeed * Time.deltaTime);
	}
}
