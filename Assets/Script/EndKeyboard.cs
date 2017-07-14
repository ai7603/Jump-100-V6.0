using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class EndKeyboard : MonoBehaviour {

	public Transform UIButtonOne;
	public Transform UIButtonTwo;

	public Transform UIImgOne;
	public Transform UIImgTwo;

	private int ButtonId;

	// Use this for initialization
	void Start () {
		ButtonId = 0;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			ButtonId = Math.Max (0, ButtonId - 1);
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			ButtonId = Math.Min (1, ButtonId + 1);
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			ButtonId = Math.Max (0, ButtonId - 1);
		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			ButtonId = Math.Min (1, ButtonId + 1);
		} else if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) {
			
			switch (ButtonId) {
			case 0:
				SceneManager.LoadScene ("scene1");
				break;
			case 1:
				SceneManager.LoadScene ("Main");
				break;
			default:
				break;	
			}
		}

		switch (ButtonId) {
		case 0:
			UIImgOne.gameObject.SetActive (true);
			UIImgTwo.gameObject.SetActive (false);
			break;
		case 1:
			UIImgOne.gameObject.SetActive (false);
			UIImgTwo.gameObject.SetActive (true);
			break;
		}

	}
}
