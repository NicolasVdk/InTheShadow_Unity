using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour {

	public bool SoundEnabled = true;
	public Texture SoundOn;
	public Texture SoundOff;
	public Texture SwitchModeNormal;
	public Texture SwitchModeTest;
	public RawImage SoundButton;
	public RawImage SwitchModeButton;
	public List<Button> Levels;
	public Text LevelInfo;

	// Use this for initialization
	void Start () {
		if (MainMenu.instance.TestMode) {
			SwitchModeButton.texture = SwitchModeTest;
		} else {
			SwitchModeButton.texture = SwitchModeNormal;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha0))
			PlayerPrefs.SetInt ("LevelUnlocked", 0);
		int ActualLevel = PlayerPrefs.GetInt ("LevelUnlocked");
		if (MainMenu.instance.TestMode)
			ActualLevel = 6;
		if (ActualLevel == 0) {
			ActualLevel = 1;
		}
		for (int i = 0; i < 5; i++) {
			if (i < ActualLevel - 1) {
				Levels [i].interactable = true;
				ParticleSystem.MainModule tmp = Levels [i].GetComponent<ParticleSystem> ().main;
				tmp.startColor = Color.white;
				Levels [i].GetComponent<ParticleSystem> ().Play ();
			}
			if (i == ActualLevel - 1) {
				Levels [i].interactable = true;
				ParticleSystem.MainModule tmp = Levels [i].GetComponent<ParticleSystem> ().main;
				tmp.startColor = Color.green;
				Levels [i].GetComponent<ParticleSystem> ().Play ();
			}
			if (i > ActualLevel - 1) {
				Levels [i].interactable = false;
				ParticleSystem.MainModule tmp = Levels [i].GetComponent<ParticleSystem> ().main;
				tmp.startColor = Color.red;
				Levels [i].GetComponent<ParticleSystem> ().Play ();
			}
		}
	}

	public void SwitchTestMode() {
		MainMenu.instance.TestMode = !MainMenu.instance.TestMode;
		if (MainMenu.instance.TestMode) {
			SwitchModeButton.texture = SwitchModeTest;
		} else {
			SwitchModeButton.texture = SwitchModeNormal;
		}
	}

	public void SoundClick() {
		if (SoundEnabled) {
			SoundEnabled = !SoundEnabled;
			AudioListener.volume = 0;
			SoundButton.texture = SoundOff;
		} else {
			SoundEnabled = !SoundEnabled;
			AudioListener.volume = 1;
			SoundButton.texture = SoundOn;
		}
	}

	public void LoadLevel(string level) {
		SceneManager.LoadScene (level);
		MainMenu.instance.levelWinned = false;
	}

	public void ChangeLevelInfo(string levelinfo) {
		LevelInfo.text = levelinfo;
	}
}
