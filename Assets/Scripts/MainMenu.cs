using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public static MainMenu instance = null;
	public static MainMenu Instance {
		get { return instance; }
	}
	public bool SoundUnlock;
	public bool levelWinned = false;
	public bool TestMode = false;
	public GameObject QuitMenu;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void LevelWin(int Level) {
		if (!levelWinned) {
			levelWinned = true;
			if (!TestMode) {
				if (PlayerPrefs.GetInt ("LevelUnlocked") < Level + 1)
					PlayerPrefs.SetInt ("LevelUnlocked", Level + 1);
			}
			GameObject WinEffect = GameObject.Find ("WinEffect");
			if (WinEffect != null) {
				WinEffect.GetComponent<ParticleSystem> ().Play ();
			}
			Instantiate (QuitMenu);
			Debug.Log ("Level Winned");
		}
	}
}
