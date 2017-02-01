using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	public int Level;
	public Puzzle Puzzle1;
	public Puzzle Puzzle2;
	public bool NeedSpecialPosition = false;
	public float DotLeftMin;
	public float DotLeftMax;
	public float DotUpMin;
	public float DotUpMax;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
		{
			if (child.tag == "Puzzle")
			{
				if (Puzzle1 == null) {
					Puzzle1 = child.GetComponent<Puzzle> ();
				} else if (NeedSpecialPosition) {
					Puzzle2 = child.GetComponent<Puzzle> ();
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Puzzle1.Resolved == true && (!NeedSpecialPosition || Puzzle2.Resolved == true)) {
			if (NeedSpecialPosition) {
				float dotLeft = Vector3.Dot (Puzzle1.transform.TransformDirection (Vector3.left), Puzzle1.transform.localPosition - Puzzle2.transform.localPosition);
				float dotUp = Vector3.Dot (Puzzle1.transform.TransformDirection (Vector3.up), Puzzle1.transform.localPosition - Puzzle2.transform.localPosition);
				Debug.Log (dotLeft);
				Debug.Log (dotUp);
				if (dotLeft >= DotLeftMin && dotLeft <= DotLeftMax && dotUp >= DotUpMin && dotUp <= DotUpMax) {
					transform.GetComponent<Move> ().move = false;
					MainMenu.Instance.LevelWin (Level);
				}
			} else {
				transform.GetComponent<Move> ().move = false;
				MainMenu.Instance.LevelWin (Level);
			}
		}
	}
}
