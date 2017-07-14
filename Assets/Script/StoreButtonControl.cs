using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButtonControl : MonoBehaviour {

	public Transform UIButton;
	public Transform UITextOne;
	public Transform UITextTwo;
	public Transform UIImg;
	private bool cont;
	// Use this for initialization
	void Start () {
		cont = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI(){
		//if(cont)
			// GUI.Button (new Rect (300, 300, 350, 350), "BOUGHT");
	}

	public void Disable_Button(){
		UIButton.gameObject.SetActive (false);
		UITextOne.gameObject.SetActive (false);
		UITextTwo.gameObject.SetActive (false);
		UIImg.gameObject.SetActive (false);
		cont = true;
	}
}