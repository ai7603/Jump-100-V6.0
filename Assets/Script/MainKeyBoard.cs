using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MainKeyBoard : MonoBehaviour {

	private int ButtonId;

	public Transform UIButtonOne;
	public Transform UIButtonTwo;
	public Transform UIButtonThree;
	public Transform UIButtonFour;
	public Transform UIButtonFive;

	public Transform UIPicOne;
	public Transform UIPicTwo;
	public Transform UIPicThree;
	public Transform UIPicFour;
	public Transform UIPicFive;
	// Use this for initialization
	void Start () {
		ButtonId = 0;
	}
	
	// Update is called once per frame
	void Update () {
		print (ButtonId);
		// 0 -- play, 1 -- logout, 2 -- store, 3 -- settings, 4 -- highest
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			ButtonId = Math.Max (0, ButtonId - 1);
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			ButtonId = Math.Min (4, ButtonId + 1);
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
				ButtonId = Math.Max (0, ButtonId - 1);
		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			ButtonId = Math.Min (4, ButtonId + 1);
		} else if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) {
			switch (ButtonId) {
			case 0:
				SceneManager.LoadScene ("scene1");
				break;
			case 1:
				//SceneManager.LoadScene ("scene1");
				Application.Quit();
				break;
			case 2:
				SceneManager.LoadScene ("Store");
				break;
			case 3:
				SceneManager.LoadScene ("Settings");
				break;
			case 4:
				SceneManager.LoadScene ("Highest");
				break;
			default:
				break;	
			}
		}

		switch (ButtonId) {
		case 0:
			UIPicOne.gameObject.SetActive (true);
			UIPicTwo.gameObject.SetActive (false);
			UIPicThree.gameObject.SetActive (false);
			UIPicFour.gameObject.SetActive (false);
			UIPicFive.gameObject.SetActive (false);
			break;
		case 1:
			UIPicOne.gameObject.SetActive (false);
			UIPicTwo.gameObject.SetActive (true);
			UIPicThree.gameObject.SetActive (false);
			UIPicFour.gameObject.SetActive (false);
			UIPicFive.gameObject.SetActive (false);
			break;
		case 2:
			UIPicOne.gameObject.SetActive (false);
			UIPicTwo.gameObject.SetActive (false);
			UIPicThree.gameObject.SetActive (true);
			UIPicFour.gameObject.SetActive (false);
			UIPicFive.gameObject.SetActive (false);
			break;
		case 3:
			UIPicOne.gameObject.SetActive (false);
			UIPicTwo.gameObject.SetActive (false);
			UIPicThree.gameObject.SetActive (false);
			UIPicFour.gameObject.SetActive (true);
			UIPicFive.gameObject.SetActive (false);
			break;
		case 4:
			UIPicOne.gameObject.SetActive (false);
			UIPicTwo.gameObject.SetActive (false);
			UIPicThree.gameObject.SetActive (false);
			UIPicFour.gameObject.SetActive (false);
			UIPicFive.gameObject.SetActive (true);
			break;
		}
	}

	public void PatchOne(){
		SceneManager.LoadScene ("scene1");
	}

	public void PatchTwo(){
		Application.Quit ();
	}
	public void PatchThree(){
		SceneManager.LoadScene ("Store");
	}
	public void PatchFour(){
		SceneManager.LoadScene ("Settings");
	}
	public void PatchFive(){
		SceneManager.LoadScene ("Highest");
	}

}
