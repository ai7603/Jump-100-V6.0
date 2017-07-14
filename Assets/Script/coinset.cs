using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
public class coinset : MonoBehaviour {

    public Text Coin;
    private int num;
    string filepath;
    string str;
	// Use this for initialization
	void Start () {
        Coin = GameObject.Find("Canvas/coin").GetComponent<Text>();
        filepath = Application.dataPath + "/StreamingAssets" + "/coin.txt";
        str = File.ReadAllText(filepath, Encoding.ASCII);
        int.TryParse(str, out num);
    }
	
    public void Add(int tmp)
    {
        num += tmp;
        string str = num.ToString();
        File.WriteAllText(filepath, str);
    }

    public void Show()
    {
        Coin.text = "Coins: " + num;
    }

	// Update is called once per frame
	void Update () {
        Show();
	}
}
