using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring_brick : MonoBehaviour {

    // Use this for initialization
    private int currframe;
    public Animator myanimator;
    void Start () {
        myanimator = this.gameObject.GetComponent<Animator>();
        myanimator.SetBool("ok", false);
       
    }
	
	// Update is called once per frame
	void Update () {
        currframe++;
        if (currframe == 30) myanimator.SetBool("ok", false);
	}
    private void OnCollisionEnter(Collision collision)
    {
        myanimator.SetBool("ok", true);
        currframe = 0; 
    }
}
