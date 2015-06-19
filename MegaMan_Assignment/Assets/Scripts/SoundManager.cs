using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;
	
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle (AudioClip clip) {
		sfxSource.clip = clip;
		sfxSource.Play ();
	}
	public void PlayMusic (AudioClip clip){
		musicSource.clip = clip;
		musicSource.Play ();
	}

}
