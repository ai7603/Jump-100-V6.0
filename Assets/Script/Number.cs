using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Number: MonoBehaviour {


     public Text NoText;
     string[] str;
     string filepath;
// Use this for initialization
     void Start () {
        NoText = GameObject.Find("Canvas/Panel/Norank").GetComponent<Text>();
        filepath = Application.dataPath + "/StreamingAssets" + "/score.txt";
        str = File.ReadAllLines(filepath, Encoding.ASCII);
     }
	
	// Update is called once per frame
	void Update () {
        NoText.text = "No.1:       " + str[0] + "\n\n" + "No.2:       " + str[1] + "\n\n" + "No.3:       " + str[2] + "\n\n" + "No.4:       " + str[3] + "\n\n" + "No.5:       " + str[4] + "\n\n" + "No.6:       " + str[5];

    }
}
