using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerStart : MonoBehaviour {

	public Text textSound;
	public GameObject helpPanel;
	AudioSource audioSource;

	void Start () {
		audioSource = GameObject.Find ("Sound").GetComponent<AudioSource> ();
	}

	public void Play() {
		SceneManager.LoadScene (1);
	}

	public void Volume () {
		if (audioSource.isPlaying) {
			audioSource.Pause ();
			PlayerPrefs.SetInt ("volumePause", 1);
			textSound.text = "Sound - On";
		} else {
			audioSource.Play ();
			PlayerPrefs.SetInt ("volumePause", 0);
			textSound.text = "Sound - Off";
		}
	}

	public void Patreon () {
		Application.OpenURL("https://www.patreon.com/hacivat");
	}
	public void Quit () {
		Application.Quit ();
	}

	public void Help (){
		if (helpPanel.activeSelf) {
			helpPanel.SetActive (false);
		} else {
			helpPanel.SetActive (true);
		}
	}

	public void Mail () {
		Application.OpenURL("mailto:pekaydin580@gmail.com");
	}
}
