using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Text scoreCount;
	public Text highScoreCount;
	public Text textSound;
	AudioSource audioSource;
	public Player playerScript;
	public GameObject pause;
	public GameObject submitPanel;
	public GameObject leaderBoardPanel;
	public GameObject helpPanel;
	public Text submitHighScore;

	void Start () {
		playerScript = playerScript.GetComponent<Player> ();
		audioSource = GameObject.Find ("Sound").GetComponent<AudioSource> ();
		highScoreCount.text = PlayerPrefs.GetInt ("highScore").ToString();
	}
	public void StartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (1);
	}
	public void PauseGame(){
		Time.timeScale = 0f;
		pause.SetActive (true);
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

	public void Resume ()  {
		pause.SetActive (false);
		Time.timeScale =1f;
	}
	public void Quit ()  {
		Application.Quit ();
	}

	public void MainMenu () {
		ScoreCounter (playerScript.score);
		SceneManager.LoadScene (0);
	}

	public void SubmitButton() {
		if (!submitPanel.activeSelf) {
			submitHighScore.text = highScoreCount.text;
			submitPanel.SetActive (true);
		} else {
			submitPanel.SetActive (false);
		}
	}
	public void LeaderBoardPanel() {
		leaderBoardPanel.SetActive (false);
	}

	public void ExitSubmitButton() {
		submitPanel.SetActive (false);
	}

	public void Patreon () {
		Application.OpenURL("https://www.patreon.com/hacivat");
	}

	public void Mail () {
		Application.OpenURL("mailto:pekaydin580@gmail.com");
	}

	public void Help (){
		if (helpPanel.activeSelf) {
			helpPanel.SetActive (false);
		} else {
			helpPanel.SetActive (true);
		}
	}
		
	public void ScoreCounter (int score) {
		scoreCount.text = score.ToString();
		if (score >= PlayerPrefs.GetInt("highScore")) {
			highScoreCount.text = scoreCount.text.ToString ();
			PlayerPrefs.SetInt ("highScore", int.Parse(highScoreCount.text));
		}
	}
}