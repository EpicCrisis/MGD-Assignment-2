using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitControllerScript : MonoBehaviour
{
	public Camera cam;

	public int clickCounter = 0;

	public float clickResetDelay = 0.5f;
	public float clickResetCounter = 0f;

	public float cameraOffset = 10f;

	RTSControllerScript rtsController;

	void Start ()
	{
		rtsController = FindObjectOfType<RTSControllerScript> ();
	}

	void Update ()
	{
		ClickUpdate ();
	}

	public void ClickPortrait (GameObject player)
	{
		clickCounter++;

		if (clickCounter >= 1) {
			
			rtsController.units.Add (player.transform);

			if (rtsController.canSound) {
				
				AudioManager.instance.Play ("Select");
				rtsController.canSound = false;
			}

			player.transform.GetChild (0).gameObject.SetActive (true);
		}

		if (clickCounter >= 2) {
			
			cam.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + cameraOffset, player.transform.position.z - cameraOffset / 2);
		}
	}

	public void ClickUpdate ()
	{
		if (clickCounter > 0) {

			clickResetCounter += Time.deltaTime;

			if (clickResetCounter >= clickResetDelay) {

				clickCounter = 0;

				clickResetCounter = 0;
			}
		}
	}
}
