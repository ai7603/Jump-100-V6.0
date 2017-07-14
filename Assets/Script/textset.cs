using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class textset : MonoBehaviour
{

    public Text Blood, GameOver, coin;
    
    public int num = 100;
	private int cnum = 0;
    // Use this for initialization

    void Start()
    {
        Blood = GameObject.Find("Canvas/blood").GetComponent<Text>();
        GameOver = GameObject.Find("Canvas/blood").GetComponent<Text>();
		coin = GameObject.Find ("Canvas/coin").GetComponent<Text> ();
    }
    public void add()
    {
        num -= 5;
    }
    public void add2()
    {
        num += 1;
    }
	public void add3(){
		num += 5;
	}
	public void addcoin(){
		cnum += 1;
	}
	public void sub20(){
		num -= 20;
	}
    public void Show()
    {
        //Debug.Log(num);
   
        if (num <= 0)
        {
            GameOver.text = "GameOver";
        }
        else
        {
            Blood.text = "HP : " + num;

        }
    }
	public void ShowCoin(){
		coin.text = "COIN : " + cnum;
	}

    // Update is called once per frame
    void Update()
    {
       
    }
}