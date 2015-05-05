using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	public Slider musicSlider;
	public Slider sfxSlider;
	public Toggle invertToggle;

	int isInverted = 0; //0 means false 1 means true
	// Use this for initialization
	void Awake () {
		if (PlayerPrefs.HasKey ("MusicVolume")) {
			musicSlider.value = PlayerPrefs.GetFloat ("MusicVolume");
		} else {
			musicSlider.value = 0.3f;
		}

		if (PlayerPrefs.HasKey ("SfxVolume")) {
			musicSlider.value = PlayerPrefs.GetFloat ("MusicVolume");
		} else {
			musicSlider.value = 0.17f;
		}

		if (PlayerPrefs.HasKey ("InvertControls")) {
			if (PlayerPrefs.GetInt ("InvertControls") == 1) {
				invertToggle.isOn = true;
			} else {
				invertToggle.isOn = false;
			}
		} else {
			invertToggle.isOn = false;	
		}

	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat ("MusicVolume", musicSlider.value);
		PlayerPrefs.SetFloat ("SfxVolume", sfxSlider.value);
		
		if (invertToggle.isOn) {
			isInverted = 1;
		}
		else{
			isInverted = 0;
		}
		PlayerPrefs.SetInt ("InvertControls", isInverted);
	}

	public void NewGame(){
		PlayerPrefs.DeleteAll ();
	}
}
