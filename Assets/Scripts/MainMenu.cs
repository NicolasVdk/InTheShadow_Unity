using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private static MainMenu instance = null;
	public static MainMenu Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel(string level) {
		SceneManager.LoadScene (level);
	}

	public void LevelWin() {
		GameObject WinEffect = GameObject.Find ("WinEffect");
		if (WinEffect != null) {
			WinEffect.GetComponent<ParticleSystem> ().Play ();
		}
		Debug.Log ("Level Winned");
	}
}
