using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchControlsScript : MonoBehaviour
{

	public RTSControllerScript selectControl;
	public DragMoveController cameraControl;

	Image image;

	void Start ()
	{
		image = GetComponent<Image> ();
	}

	void Update ()
	{
		
	}

	public void ChangeControl ()
	{
		if (selectControl.enabled) {
			
			Debug.Log ("Camera Drag Enabled");

			image.color = Color.yellow;
			selectControl.enabled = false;
			cameraControl.enabled = true;

		} else if (cameraControl.enabled) {
			
			Debug.Log ("Box Selection Enabled");

			image.color = Color.cyan;
			cameraControl.enabled = false;
			selectControl.enabled = true;
		}
	}
}
