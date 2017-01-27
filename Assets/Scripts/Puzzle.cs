using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

	public Vector3 Resolve;
	public bool Resolved = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Quaternion.Dot (transform.rotation, Quaternion.Euler (Resolve)));
		if (Quaternion.Dot(transform.rotation, Quaternion.Euler(Resolve)) > 0.9999f || Quaternion.Dot(transform.rotation, Quaternion.Euler(Resolve)) < -0.9999f) {
			Debug.Log ("Good");
		}
	}
}
