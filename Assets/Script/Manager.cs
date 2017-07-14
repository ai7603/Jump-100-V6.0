using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Manager : MonoBehaviour {

    [SerializeField]
    Transform UIPanel; //Will assign our panel to this variable so we can enable/disable it
    [SerializeField]
    Text timeText; //Will assign our Time Text to this variable so we can modify the text it displays.

    int counter;

    bool isPaused; //Used to determine paused state

    void Start()
    {
        counter = 0;
        Time.timeScale = 1f;

        UIPanel.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
        isPaused = false; //make sure isPaused is always false when our scene opens
    }

    void Update()
    {
        // print(isPaused ? "True" : "False");
        // timeText.text = "Time Since Startup: " + Time.timeSinceLevelLoad; //Tells us the time since the scene loaded
        timeText.text = "Time Since Startup: " + counter;
        counter++;
        //If player presses escape and game is not paused. Pause game. If game is paused and player presses escape, unpause.
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
           // print("isPaused == false");
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
          //  print("isPaused == true");
            UnPause();
        }
    }

    public void Pause()
    {
        isPaused = true;
		GetComponent<scene1Keyboard> ().ControlInPausedPanel = false;
        UIPanel.gameObject.SetActive(true); //turn on the pause menu
        Time.timeScale = 0f; //pause the game
    }

    public void UnPause()
    {
        isPaused = false;
		GetComponent<scene1Keyboard> ().ControlInPausedPanel = true;
        UIPanel.gameObject.SetActive(false); //turn off pause menu

        Time.timeScale = 1f; //resume game
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        counter = 0;
        // Application.LoadLevel(0);

        SceneManager.LoadScene("scene1");
    }

}
