using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

	const string privateCode = "f-BeLNUPFEqwAbM3zt6HrAY079EUBF2kOi3TkNsub2_w";
	const string publicCode = "5a3ee9166b2b65f29cbaf6a6";
	const string webURL = "http://dreamlo.com/lb/";

	public Text inputText;
	public Text warningText;
	public Text userNameText;
	public Text scoreText;
	public GameObject lBPanel;
	public GameObject submitPanel;
	public GameObject warningPanel;

	public Text[] arrayScores = new Text[10];


	public void OnButtonSubmit () {
		if (string.IsNullOrEmpty(inputText.text)) {
			warningText.text = "Please write something";
			warningPanel.SetActive (true);
		}
		else if (inputText.text.Length > 8) {
			warningText.text = "Max. 8 char";
			warningPanel.SetActive (true);
		} else {
			Upload (userNameText.text, scoreText.text);
			submitPanel.SetActive (false);
			lBPanel.SetActive (true);
			Download ();
		}
	}

	public void OK () {
		warningPanel.SetActive (false);
	}

	public void OnButtonLeaderBoard () {
		lBPanel.SetActive (true);
		Download ();
	}

	public void Upload(string username , string score) {
		StartCoroutine (UploadHighScore (username, score));
	}

	public void Download () {
		StartCoroutine ("DownloadScoresFromDB");
	}

	IEnumerator UploadHighScore(string username, string score){
		WWW www = new WWW (webURL + privateCode + "/add/" + WWW.EscapeURL (username) + "/" + score);
		yield return www;
		if (!string.IsNullOrEmpty(www.error)) {
			Debug.Log ("Error: " + www.error);
		}
	}

	IEnumerator DownloadScoresFromDB() {
		WWW www = new WWW (webURL + publicCode + "/pipe");
		yield return www;
		if (string.IsNullOrEmpty(www.error)) {
			Splitter (www.text);
		} else {
			Debug.Log ("Error: " + www.error);
		}
	}
		
	void Splitter (string data) {
		string[] rows = data.Split (new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		string[] userNames = new string[rows.Length];
		string[] scores = new string[rows.Length];
		for (int i = 0; i < rows.Length; i++) {
			userNames [i] = rows [i].Split ('|')[0];
			scores [i] = rows [i].Split ('|')[1]; 
		}

		for (int i = 0; i < arrayScores.Length; i++) {
			try {
				arrayScores [i].text = i + 1 + ". " + userNames [i] + " - " + scores [i]; 
			} catch {
				break;
			}
		}
	}
}
