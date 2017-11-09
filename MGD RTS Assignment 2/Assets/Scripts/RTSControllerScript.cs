using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RTSControllerScript : MonoBehaviour
{

	Rect rect = new Rect ();
	Vector3 startPos;
	Vector3 endPos;
	public Texture texture;

	Ray ray;
	RaycastHit hit;

	public List<Transform> units = new List<Transform> ();

	public Transform pointer;

	public float soundDelay = 3f;
	public float soundDelayCounter = 0f;

	public bool canSound = true;

	//public List<ObjectMoveScript> objectScript = new List<ObjectMoveScript> ();

	void Start ()
	{
		
	}

	void Update ()
	{
		if (!GameSettings.instance.isPaused) {
			//on input down
			if (Input.GetMouseButtonDown (0)) {

				GameObject[] gos = GameObject.FindGameObjectsWithTag ("Player");
				
				rect = new Rect ();
				startPos = Input.mousePosition;
				endPos = Vector3.zero;

				units = new List<Transform> (); //resets the list

				if (gos.Length > 0) {
					for (int i = 0; i < gos.Length; i++) {
						gos [i].transform.GetChild (0).gameObject.SetActive (false);
					}
				}
			}

			//on input drag
			if (Input.GetMouseButton (0)) {
				
				endPos = Input.mousePosition;
				Vector3 size = endPos - startPos;
				rect = new Rect (startPos.x, startPos.y, size.x, size.y);
			}

			//on input up
			if (Input.GetMouseButtonUp (0)) {

				GameObject[] gos = GameObject.FindGameObjectsWithTag ("Player");

				//Debug.Log (rect);
				//Debug.Log (gos.Length);

//				if (gos.Length > 0) {
//					for (int i = 0; i < gos.Length; i++) {
//
//						units.Remove (gos [i].transform);
//						gos [i].transform.GetChild (0).gameObject.SetActive (false);
//					}
//				}

				for (int i = 0; i < gos.Length; i++) {
					if (rect.Contains (Camera.main.WorldToScreenPoint (gos [i].transform.position), true)) {
					
						Debug.Log (string.Format ("{0} REPORTING", gos [i].name));

						if (canSound) {
							AudioManager.instance.Play ("Select");
							canSound = false;
						}

						units.Add (gos [i].transform);

						gos [i].transform.GetChild (0).gameObject.SetActive (true);
					}
				}

				ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.tag == "Player") {

						Debug.Log (string.Format ("{0} REPORTING", hit.transform.name));

						if (canSound) {
							AudioManager.instance.Play ("Select");
							canSound = false;
						}

						units.Add (hit.transform);

						hit.transform.GetChild (0).gameObject.SetActive (true);
					}
				}

				rect = new Rect ();
			}
			
			if (Input.GetMouseButton (1) || Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				// To test rotation on ramps! //

				if (Physics.Raycast (ray, out hit)) {
					if (hit.transform.tag == "Ground") {

						//Debug.Log ("Create Marker");
						//Debug.DrawLine (ray.origin, hit.point);

						pointer.position = new Vector3 (hit.point.x, hit.point.y + 0.1f, hit.point.z);
						pointer.rotation = Quaternion.FromToRotation (pointer.forward, hit.normal) * pointer.rotation;

						//int columns = CalculateColumns (units.Count);

						int horizontalSpacing = 0;
						//int verticalSpacing = 0;

						Vector3 movePos1;

						for (int i = 0; i < units.Count; i++) {

							if (i >= 0) {
								
								movePos1 = new Vector3 (pointer.position.x + horizontalSpacing, pointer.position.y, pointer.position.z);

								horizontalSpacing += 2;

								//						for (int j = units.Count / columns; j < units.Count; j++) {
								//
								//							Vector3 movePos2 = new Vector3 (pointer.position.x, pointer.position.y, pointer.position.z - j);
								//
								//							units [j].GetComponent<ObjectMoveScript> ().navMeshAgent.SetDestination (movePos2);
								//						}

								units [i].GetComponent<ObjectMoveScript> ().navMeshAgent.SetDestination (movePos1);

								if (canSound) {
									AudioManager.instance.Play ("Move");
									canSound = false;
								}
							}
						}
					} else {

						return;
					}
				}
			}
		}

		UpdateSound ();
	}

	int CalculateColumns (int index)
	{
		int amount = index;
		//int column;

		return (int)Mathf.Sqrt (amount);
	}

	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (rect.x, Screen.height - rect.y, rect.width, -rect.height), texture);
	}

	void UpdateSound ()
	{
		if (!canSound) {
			
			soundDelayCounter += Time.deltaTime;

			if (soundDelayCounter >= soundDelay) {
				
				canSound = true;

				soundDelayCounter = 0f;
			}
		}
	}
}
