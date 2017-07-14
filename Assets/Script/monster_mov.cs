using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_mov : MonoBehaviour {
    private int currframe;
    public Animator myanimator; 
	// Use this for initialization
	void Start () {
        myanimator = this.gameObject.GetComponent<Animator>();
        myanimator.SetBool("mov", true);
        //currframe = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //currframe++;
        //if (currframe % 60 == 0) myanimator.SetBool("mov", true);
        //myanimator.SetBool("mov", false);
	}
}
