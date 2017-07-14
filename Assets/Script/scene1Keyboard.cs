using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class scene1Keyboard : MonoBehaviour {

	public Transform UIButtonOne;
	public Transform UIButtonTwo;
	public Transform UIButtonThree;

	public Transform UIImgOne;
	public Transform UIImgTwo;
	public Transform UIImgThree;

	public Transform UIPanel;

	private int ButtonId;
	public bool ControlInPausedPanel;

	// Use this for initialization
	void Start () {
		ButtonId = 0;
		ControlInPausedPanel = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			ButtonId = Math.Max (0, ButtonId - 1);
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			ButtonId = Math.Min (2, ButtonId + 1);
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			ButtonId = Math.Max (0, ButtonId - 1);
		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			ButtonId = Math.Min (2, ButtonId + 1);
		} else if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) {
			ControlInPausedPanel = true;
			switch (ButtonId) {
			case 0:
				UIPanel.gameObject.SetActive(false); //turn off pause menu
				Time.timeScale = 1f; //resume game
				break;
			case 1:
				//SceneManager.LoadScene ("scene1");
				SceneManager.LoadScene("scene1");
				break;
			case 2:
				Application.Quit ();
				break;
			default:
				break;	
			}
		}

		switch (ButtonId) {
		case 0:
			UIImgOne.gameObject.SetActive (true);
			UIImgTwo.gameObject.SetActive (false);
			UIImgThree.gameObject.SetActive (false);
			break;
		case 1:
			UIImgOne.gameObject.SetActive (false);
			UIImgTwo.gameObject.SetActive (true);
			UIImgThree.gameObject.SetActive (false);
			break;
		case 2:
			UIImgOne.gameObject.SetActive (false);
			UIImgTwo.gameObject.SetActive (false);
			UIImgThree.gameObject.SetActive (true);
			break;
		}
		if (ControlInPausedPanel) {
			UIImgOne.gameObject.SetActive (false);
			UIImgTwo.gameObject.SetActive (false);
			UIImgThree.gameObject.SetActive (false);
		}
	}
}
