using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    [SerializeField]
    Transform UIPanel; //Will assign our panel to this variable so we can enable/disable it
    
    public void StartGame()
    {
        print("StartGame!");
        //SceneManager.LoadScene("Test");
        SceneManager.LoadScene("scene1");
    }

    public void Highest()
    {
        print("Highest");
        SceneManager.LoadScene("Highest");
    }

    public void Quit()
    {
        print("Quit");
        Application.Quit();
    }
    void Update()
    {

        //  if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        //       Pause();
        //   else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        //      UnPause();
    }
	public void gotoStore(){
		SceneManager.LoadScene ("Store");
	}
	public void gotoSettings(){
		SceneManager.LoadScene ("Settings");
	}
}
