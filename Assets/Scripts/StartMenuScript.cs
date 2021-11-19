using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highScoreText;

    private void Start()
    {
        highScoreText.text = "Until now highscore is " + PlayerPrefs.GetInt("HIGHSCORE")  + " give it a chance, maybe you can break it";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
