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

	void Start ()
	{
		
	}

	void Update ()
	{
		//on input down
		if (Input.GetMouseButtonDown (0)) {
			rect = new Rect ();
			startPos = Input.mousePosition;
			endPos = Vector3.zero;
			units = new List<Transform> ();
		}

		//on input drag
		if (Input.GetMouseButton (0)) {
			endPos = Input.mousePosition;
			Vector3 size = endPos - startPos;
			rect = new Rect (startPos.x, startPos.y, size.x, size.y);
		}

		//on input up
		if (Input.GetMouseButtonUp (0)) {

			//Debug.Log (rect);
			//Debug.Log (gos.Length);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("Player");

			for (int i = 0; i < gos.Length; i++) {
				
				units.Remove (gos [i].transform);
				gos [i].transform.GetChild (0).gameObject.SetActive (false);
				gos [i].GetComponent<ObjectMoveScript> ().isSelected = false;
			}

			for (int i = 0; i < gos.Length; i++) {
				if (rect.Contains (Camera.main.WorldToScreenPoint (gos [i].transform.position), true)) {
					
					units.Add (gos [i].transform);
					Debug.Log (string.Format ("{0} REPORTING", gos [i].name));
					gos [i].transform.GetChild (0).gameObject.SetActive (true);
					gos [i].GetComponent<ObjectMoveScript> ().isSelected = true;
				}
			}

			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "Player") {

					Debug.Log (string.Format ("{0} REPORTING", hit.transform.name));
					hit.transform.GetChild (0).gameObject.SetActive (true);
					hit.transform.GetComponent<ObjectMoveScript> ().isSelected = true;
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
				}
			}
		}
	}


	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (rect.x, Screen.height - rect.y, rect.width, -rect.height), texture);
	}
}
