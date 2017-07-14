using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class scoreset : MonoBehaviour
{
  
    public Text ScoreText;
    public int score = 0;
    // Use this for initialization

    void Start()
    {
        ScoreText = GameObject.Find("Canvas/score").GetComponent<Text>();
       
    }
    public void add()
    {
        score++;
     }
    void Show()
    {
        ScoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        Show();
    }
}