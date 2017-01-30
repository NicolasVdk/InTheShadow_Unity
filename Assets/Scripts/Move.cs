using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public Puzzle Selected;
	public float SpeedRotate = 3;
	public bool CanRotateHorizontaly = false;
	public bool CanRotateVerticaly = false;
	public bool CanMove = false;

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) {
				if (hit.transform.tag == "Puzzle") {
					Selected = hit.transform.gameObject.GetComponent<Puzzle>();
				}
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			Selected = null;
		}
		if (Selected != null && !Selected.Resolved) {
			if (!Input.GetKey (KeyCode.LeftShift)) {
				if (CanRotateHorizontaly && !Input.GetKey (KeyCode.LeftControl))
					Selected.transform.Rotate (new Vector3 (0, -Input.GetAxis ("Mouse X"), 0), Space.World);
				if (CanRotateVerticaly && Input.GetKey (KeyCode.LeftControl))
					Selected.transform.Rotate (new Vector3 (-Input.GetAxis ("Mouse Y"), 0, 0), Space.World);
			} else if (CanMove && Input.GetKey (KeyCode.LeftShift)) {
				Selected.transform.Translate(new Vector3(-Input.GetAxis("Mouse X") / 4, Input.GetAxis("Mouse Y") / 4, 0), Space.World);
			}
		}
	}
}
