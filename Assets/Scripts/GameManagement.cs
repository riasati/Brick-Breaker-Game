using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsBallMove = false;
    public static int currentLevel = 1;
    public int score;
    public int lives;
    public int noBricks;
    public Text scoreText;
    public Text liveText;
    public Text noBricksText;
    public Text highScoreText;
    public bool gameFreeze = false;
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;
    public Transform[] levels;
    public GameObject ball;
    void Start()
    {
        scoreText.text = "Score: " + score;
        liveText.text = "Lives: " + lives;
        noBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        noBricksText.text = "Bricks to Break: " + noBricks;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        liveText.text = "Lives: " + lives;
        
    }
    
    public void UpdateScores(int changeInScore)
    {
        score += changeInScore;
        scoreText.text = "Score: " + score;
        
    }

    public void GameOver()
    {
        gameFreeze = true;
        gameOverPanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE",score);
            highScoreText.text = "Congratulation!!!\n" + "New HighScore is: " + score;
        }
        else
        {
            highScoreText.text = "Previous HighScore is: " + highScore + "\nCan you beat it?!!!";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scenes/StartMenu");
    }

    public void UpdateNoBricks(int changeInNoBrick)
    {
        noBricks += changeInNoBrick;
        if (noBricks <= 0)
        {
            noBricks = 0;
            if (currentLevel >= levels.Length)
            {
                GameOver();
            }
            else
            {
                //gameFreeze = true;
                nextLevelPanel.SetActive(true);
                nextLevelPanel.GetComponentInChildren<Text>().text = "Loading Level " + currentLevel + " ...";
                Invoke("NextLevel",1.5f);
            }
        }
        noBricksText.text = "Bricks to Break: " + noBricks;
    }

    public void NextLevel()
    {
        currentLevel++;
        noBricksText.text = "Bricks to Break: " + noBricks;
        //gameFreeze = false;
        nextLevelPanel.SetActive(false);
        Instantiate(levels[currentLevel - 1], Vector2.zero, Quaternion.identity);
        noBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }
}
